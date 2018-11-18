using frettir.Models;
using frettir.Services;
using frettir.Utils;
using frettir.ViewModels;
using Xamarin.Forms;

namespace frettir.Views
{
    public partial class MainPage : TabbedPage
    {
        #region Init

        public MainPage()
        {
            InitializeComponent();

            // Add stored feed pages
            AddStoredPostListPages();

            // Subscribe to messaging center
            MessagingCenter.Subscribe<SettingsViewModel, Feed>(this, Constants.NOTIFICATION_ID_ADDTABITEM, OnAddItemMessage);
        }

        #endregion

        #region Event handler

        void OnAddItemMessage(SettingsViewModel sender, Feed feed)
        {
            AddFeedPostListPage(feed);
            SelectedItem = Children[0];
        }

        #endregion

        #region Private helper

        /// <summary>
        /// Addsin-app stored feed post list pages.
        /// </summary>
        void AddStoredPostListPages()
        {
            foreach(var feed in FeedPreferenceService.GetFeeds())
            {
                AddFeedPostListPage(feed);
            }
        }

        /// <summary>
        /// Adds a new feed post list page.
        /// </summary>
        /// <param name="feed">Feed.</param>
        void AddFeedPostListPage(Feed feed)
        {
            var navigationPage = new NavigationPage(new PostListPage(new PostListViewModel(feed)))
            {
                Title = feed.ShortendTitle,
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
