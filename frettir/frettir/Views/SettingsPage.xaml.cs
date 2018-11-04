using System;
using System.Collections.Generic;
using frettir.ViewModels;
using Xamarin.Forms;

namespace frettir.Views
{
    public partial class SettingsPage : ContentPage
    {
        private SettingsViewModel viewModel;

        public SettingsPage()
        {
            InitializeComponent();

            viewModel = new SettingsViewModel();
            BindingContext = viewModel;
            UrlEntry.Text = "https://dbudwm.wordpress.com/feed";
        }
    }
}
