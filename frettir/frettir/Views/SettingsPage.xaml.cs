﻿using System;
using System.Collections.Generic;
using frettir.Utils;
using frettir.ViewModels;
using Xamarin.Forms;

namespace frettir.Views
{
    public partial class SettingsPage : ContentPage
    {
        private SettingsViewModel viewModel;

        public SettingsPage()
        {
            // Setup page
            InitializeComponent();
            BindingContext = viewModel = new SettingsViewModel();

            // Handle messages
            MessagingCenter.Subscribe<SettingsViewModel>(this, Constants.NOTIFICATION_ID_ADDFEED_SUCCESS, OnSuccess);
            MessagingCenter.Subscribe<SettingsViewModel>(this, Constants.NOTIFICATION_ID_ADDFEED_FAILED, OnFailed);

            // Dev helper
            UrlEntry.Text = "https://dbudwm.wordpress.com/feed";
        }

        void OnSuccess(SettingsViewModel obj)
        {
            DisplayAlert("Success", "Adding of the feed succeeded.", "OK");
        }

        void OnFailed(SettingsViewModel obj)
        {
            DisplayAlert("Error", "Adding of the feed failed.", "OK");
        }
    }
}
