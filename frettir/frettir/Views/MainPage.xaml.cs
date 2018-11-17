using System;
using System.Collections.Generic;
using frettir.Models;
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
            AddFeedPostPage(feed);
            SelectedItem = Children[0];
        }

        #endregion

        #region Private helper

        void AddStoredPostListPages()
        {
            // Create for each stored feed a new page
            var feed = new Feed
            {
                Title = "Der Bayer und der Würschtlmann"
            };
            AddFeedPostPage(feed);
            SelectedItem = Children[0];
        }

        void AddFeedPostPage(Feed feed)
        {
            var viewModel = new PostListViewModel("https://dbudwm.wordpress.com/feed");
            var navigationPage = new NavigationPage(new PostListPage(viewModel))
            {
                Title = feed.Title.Substring(0, 15),
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
