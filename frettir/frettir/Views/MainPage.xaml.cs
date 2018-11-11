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
        public MainPage()
        {
            InitializeComponent();

            AddStoredPostListPages();
            AddStoredPostListPages();
            AddStoredPostListPages();
            AddStoredPostListPages();
            AddStoredPostListPages();
            AddStoredPostListPages();

            MessagingCenter.Subscribe<SettingsViewModel, Feed>(this, Constants.NOTIFICATION_ID_ADDTABITEM, OnAddItemMessage);
        }

        void AddStoredPostListPages()
        {

            var feed = new Feed
            {
                Title = "Der Bayer und der Würschtlmann"
            };
            AddFeedPostPage(feed);
            SelectedItem = Children[0];
        }

        void OnAddItemMessage(SettingsViewModel sender, Feed feed)
        {
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

            if(Device.RuntimePlatform == Device.iOS)
            {
                navigationPage.Icon = "tab_about.png";
            }

            Children.Insert(0, navigationPage);
        }
    }
}
