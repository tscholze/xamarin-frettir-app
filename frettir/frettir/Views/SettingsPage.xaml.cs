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
            BindingContext = viewModel = new SettingsViewModel();

            // Handle messages
            MessagingCenter.Subscribe<SettingsViewModel>(this, Constants.NOTIFICATION_ID_ADDFEED_FAILED, OnFailed);

            // Dev helper
            UrlEntry.Text = "https://dbudwm.wordpress.com/feed";
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
