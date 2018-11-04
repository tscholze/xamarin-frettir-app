using System;
using System.Windows.Input;
using frettir.Utils;
using frettir.Services;
using Xamarin.Forms;

namespace frettir.ViewModels
{
    public class SettingsViewModel : BaseViewModel
    {
        public ICommand AddNewFeedCommand { get; }

        public SettingsViewModel()
        {
            AddNewFeedCommand = new Command<string>(AddNewFeed);
        }

        void AddNewFeed(string urlString)
        {
            // Check for valid url
            if (!UriHelper.IsValidUrl(urlString) == true)
            {
                MessagingCenter.Send<SettingsViewModel>(this, Constants.NOTIFICATION_ID_ADDFEED_FAILED);
                return;
            }

            // Check if blog feed has posts
            if (WordpressService.GetPosts(urlString).Count == 0)
            {
                MessagingCenter.Send<SettingsViewModel>(this, Constants.NOTIFICATION_ID_ADDFEED_FAILED);
                return;
            }

            // Process valid blog feed
            MessagingCenter.Send<SettingsViewModel>(this, Constants.NOTIFICATION_ID_ADDFEED_SUCCESS);
            MessagingCenter.Send<SettingsViewModel, string>(this, Constants.NOTIFICATION_ID_ADDTABITEM, urlString);
        }
    }
}
