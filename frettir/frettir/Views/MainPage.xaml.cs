using frettir.Controls;
using frettir.Models;
using frettir.Services;
using frettir.Utils;
using frettir.ViewModels;
using Xamarin.Forms;
using XF.Material.Forms.UI;

namespace frettir.Views
{
    public partial class MainPage : TabbedPage
    {
        #region Init

        public MainPage()
        {
            InitializeComponent();

            // Add stored feed pages
            CreateChildren();

            // Subscribe to messaging center
            MessagingCenter.Subscribe<SettingsViewModel, Feed>(this, Constants.NOTIFICATION_ID_FEED_ITEM_ADD_SUCCEEDED, OnAddItemMessageRequested);
            MessagingCenter.Subscribe<SettingsViewModel>(this, Constants.NOTIFICATION_ID_FEED_ITEM_UPDATED, OnFeedUpdatedRequested);
            MessagingCenter.Subscribe <Application>(this, Constants.NOTIFICATION_ID_SHOW_SETTINGS_PAGE, OnShowSettingsPageRequested);
        }

        #endregion

        #region Event handler

        protected override void OnAppearing()
        {
            base.OnAppearing();

            XF.Material.Forms.Material.PlatformConfiguration.ChangeStatusBarColor(Color.Red);
        }

        /// <summary>
        /// Called on a feed item was added succesful.
        /// </summary>
        /// <param name="sender">Sender.</param>
        /// <param name="feed">Feed.</param>
        void OnAddItemMessageRequested(SettingsViewModel sender, Feed feed)
        {
            AddFeedPostListPage(feed);
            SelectedItem = Children[0];
        }

        /// <summary>
        /// Called on if at least one feed got updated.
        /// </summary>
        /// <param name="sender">Sender</param>
        void OnFeedUpdatedRequested(SettingsViewModel sender)
        {
            CreateChildren();
        }

        /// <summary>
        /// Shows the settings page.
        /// </summary>
        /// <param name="sender">Sender.</param>
        public void OnShowSettingsPageRequested(Application sender)
        {
            Navigation.PushModalAsync(new SettingsPage());
        }


        #endregion

        #region Private helper

        /// <summary>
        /// Adds in-app stored feed post list pages.
        /// </summary>
        void CreateChildren()
        {
            Children.Clear();

            var feeds = FeedPreferenceService.GetFeeds();

            if (feeds.Count == 0)
            {
                AddEmptyPage();
            }
            else
            {
                foreach (var feed in feeds)
                {
                    AddFeedPostListPage(feed);
                }
            }
        }

        /// <summary>
        /// Adds the empty feed list page.
        /// </summary>
        void AddEmptyPage()
        {
            var contentPage = new EmptyPage
            {
                Title = "Welcome"
            };

            var navigationPage = new FRNavigationPage(contentPage)
            {
                Title = "Welcome"
            };

            if (Device.RuntimePlatform == Device.iOS)
            {
                navigationPage.Icon = "tab_about.png";
            }

            Children.Insert(0, navigationPage);
        }

        /// <summary>
        /// Adds a new feed post list page.
        /// </summary>
        /// <param name="feed">Feed.</param>
        void AddFeedPostListPage(Feed feed)
        {
            var navigationPage = new FRNavigationPage(new PostListPage(new PostListViewModel(feed)))
            {
                Title = feed.ShortendTitle
            };

            if (Device.RuntimePlatform == Device.iOS)
            {
                navigationPage.Icon = "tab_about.png";
            }

            Children.Insert(0, navigationPage);
        }

        #endregion
    }
}
