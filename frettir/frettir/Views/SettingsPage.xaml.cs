using System;
using System.Collections.Generic;
using frettir.Utils;
using frettir.ViewModels;
using Xamarin.Forms;

namespace frettir.Views
{
    public partial class SettingsPage : ContentPage
    {
        #region Properties

        SettingsViewModel viewModel;

        #endregion

        #region Init
        public SettingsPage()
        {
            // Setup page
            InitializeComponent();
            Title = "Settings";
            BindingContext = viewModel = new SettingsViewModel();

            // Handle messages
            MessagingCenter.Subscribe<SettingsViewModel>(this, Constants.NOTIFICATION_ID_FEED_ITEM_ADD_SUCCEEDED, OnFailed);
        }

        #endregion

        #region Event handler

        void OnFailed(SettingsViewModel obj)
        {
            DisplayAlert("Error", "Adding of the feed failed.", "OK");
        }

        #endregion
    }
}
