using System;
using System.Collections.Generic;
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

            MessagingCenter.Subscribe<SettingsViewModel, string>(this, Constants.NOTIFICATION_ID_ADDTABITEM, OnAddItemMessage);
        }

        void AddStoredPostListPages()
        {
            AddFeedPostPage("https://dbudwm.wordpress.com/feed");
            SelectedItem = Children[0];
        }

        void OnAddItemMessage(SettingsViewModel sender, string urlString)
        {
            AddFeedPostPage(urlString);
            SelectedItem = Children[0];
        }

        void AddFeedPostPage(string urlString)
        {
            var viewModel = new PostListViewModel(urlString);
            var navigationPage = new NavigationPage(new PostListPage(viewModel))
            {
                Title = "Saved",
                Icon = "tab_about.png"
            };

            Children.Insert(0, navigationPage);
        }
    }
}
