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

            MessagingCenter.Subscribe<SettingsViewModel, string>(this, Constants.NOTIFICATION_ID_ADDTABITEM, OnAddItemMessage);
        }

        private void OnAddItemMessage(SettingsViewModel sender, string urlString)
        {
            // Build new navigation page
            var viewModel = new PostListViewModel(urlString);
            var navigationPage = new NavigationPage(new PostListPage(viewModel))
            {
                Title = "Test",
                Icon = "tab_about.png"
            };

            // Add and select page as first in row
            Children.Insert(0, navigationPage);
            SelectedItem = Children[0];
        }
    }
}
