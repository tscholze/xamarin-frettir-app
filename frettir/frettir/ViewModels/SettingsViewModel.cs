using System.Windows.Input;
using frettir.Utils;
using frettir.Services;
using Xamarin.Forms;
using Xamarin.Essentials;
using XF.Material.Forms.UI.Dialogs;

namespace frettir.ViewModels
{
    public class SettingsViewModel : BaseViewModel
    {
        #region Properties

        /// <summary>
        /// Gets the add new feed command.
        /// </summary>
        /// <value>The add new feed command.</value>
        public ICommand AddNewFeedCommand { get; }

        /// <summary>
        /// Gets the go to repository website command.
        /// </summary>
        /// <value>The go to repository command.</value>
        public ICommand GoToRepositoryCommand { get; }

        /// <summary>
        /// Gets the remove all persisted feeds command.
        /// </summary>
        /// <value>The remove all feeds command.</value>
        public ICommand RemoveAllFeedsCommand { get; }

        /// <summary>
        /// Gets the close modal page command.
        /// </summary>
        /// <value>The close page command.</value>
        public ICommand ClosePageCommand { get; }

        #endregion

        #region Init

        public SettingsViewModel()
        {
            AddNewFeedCommand = new Command<string>(AddNewFeed);
            GoToRepositoryCommand = new Command(GoToRepository);
            RemoveAllFeedsCommand = new Command(RemoveAllFeedsAsync);
            ClosePageCommand = new Command(ClosePage);
        }

        #endregion

        #region Private helper

        /// <summary>
        /// Adds the new feed.
        /// </summary>
        /// <param name="urlString">URL string.</param>
        void AddNewFeed(string urlString)
        {
            // Check for valid url.
            if (!UriHelper.IsValidUrl(urlString) == true)
            {
                MessagingCenter.Send(this, Constants.NOTIFICATION_ID_FEED_ITEM_ADD_SUCCEEDED);
                return;
            }

            // Check if blog feed has posts.
            var feed = WordpressService.GetPosts(urlString);
            if (feed.Posts.Count == 0)
            {
                MessagingCenter.Send(this, Constants.NOTIFICATION_ID_FEED_ITEM_ADD_SUCCEEDED);
                return;
            }

            // Store to preferences.
            FeedPreferenceService.AddFeed(feed);

            // Process valid blog feed.
            MessagingCenter.Send(this, Constants.NOTIFICATION_ID_FEED_ITEM_ADD_SUCCEEDED, feed);

            // Close page after command was executed.
            ClosePage();
        }

        /// <summary>
        /// Jumps to the respository's webpage.
        /// </summary>
        async void GoToRepository()
        {
            await Browser.OpenAsync(Constants.URI_REPOSITORY, BrowserLaunchMode.SystemPreferred);
        }

        /// <summary>
        /// Triggeres the removing of all stored feeds.
        /// </summary>
        async void RemoveAllFeedsAsync()
        {
            // Confirm user's choice.
            var confirmed = await MaterialDialog.Instance.ConfirmAsync(message: "Are you sure?",
                                    title: "Confirm",
                                    confirmingText: "Delete",
                                    dismissiveText: "No");

            // Cancel operation if user declined.
            if (confirmed == false)
                return;

            // Remove all feeds from storage.
            FeedPreferenceService.RemoveAll();

            // Raise notifications that feed(s) has been updated aka. removed.
            MessagingCenter.Send(this, Constants.NOTIFICATION_ID_FEED_ITEM_UPDATED);

            // Close page after command was executed.
            ClosePage();
        }

        /// <summary>
        /// Closes the modal.
        /// </summary>
        void ClosePage()
        {
            Application.Current.MainPage.Navigation.PopModalAsync();
        }

        #endregion
    }
}
