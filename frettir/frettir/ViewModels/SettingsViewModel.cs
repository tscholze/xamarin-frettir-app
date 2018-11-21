using System.Windows.Input;
using frettir.Utils;
using frettir.Services;
using Xamarin.Forms;
using Xamarin.Essentials;

namespace frettir.ViewModels
{
    public class SettingsViewModel : BaseViewModel
    {
        #region Properties

        public ICommand AddNewFeedCommand { get; }

        public ICommand GoToRepositoryCommand { get; }

        public ICommand RemoveAllFeedsCommand { get; }

        public ICommand ClosePageCommand { get; }

        #endregion

        #region Init

        public SettingsViewModel()
        {
            AddNewFeedCommand = new Command<string>(AddNewFeed);
            GoToRepositoryCommand = new Command(GoToRepository);
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
            // Check for valid url
            if (!UriHelper.IsValidUrl(urlString) == true)
            {
                MessagingCenter.Send(this, Constants.NOTIFICATION_ID_FEED_ITEM_ADD_SUCCEEDED);
                return;
            }

            // Check if blog feed has posts
            var feed = WordpressService.GetPosts(urlString);
            if (feed.Posts.Count == 0)
            {
                MessagingCenter.Send(this, Constants.NOTIFICATION_ID_FEED_ITEM_ADD_SUCCEEDED);
                return;
            }

            // Store to preferences
            FeedPreferenceService.AddFeed(feed);

            // Process valid blog feed
            MessagingCenter.Send(this, Constants.NOTIFICATION_ID_FEED_ITEM_ADD_SUCCEEDED, feed);
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
        void RemoveAllFeeds()
        {
            // Remove all feeds from storage.
            FeedPreferenceService.RemoveAll();

            // Raise notifications that feed(s) has been updated aka. removed.
            MessagingCenter.Send(this, Constants.NOTIFICATION_ID_FEED_ITEM_UPDATED);
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
