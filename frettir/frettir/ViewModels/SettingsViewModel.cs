using System;
using System.Windows.Input;
using frettir.Utils;
using frettir.Services;
using Xamarin.Forms;
using frettir.Models;

namespace frettir.ViewModels
{
    public class SettingsViewModel : BaseViewModel
    {
        #region Properties

        public ICommand AddNewFeedCommand { get; }

        #endregion

        #region Init

        public SettingsViewModel()
        {
            AddNewFeedCommand = new Command<string>(AddNewFeed);
        }

        #endregion

        #region Private helper

        void AddNewFeed(string urlString)
        {
            // Check for valid url
            if (!UriHelper.IsValidUrl(urlString) == true)
            {
                MessagingCenter.Send(this, Constants.NOTIFICATION_ID_ADDFEED_FAILED);
                return;
            }

            // Check if blog feed has posts
            var feed = WordpressService.GetPosts(urlString);
            if (feed.Posts.Count == 0)
            {
                MessagingCenter.Send(this, Constants.NOTIFICATION_ID_ADDFEED_FAILED);
                return;
            }

            // Process valid blog feed
            MessagingCenter.Send(this, Constants.NOTIFICATION_ID_ADDTABITEM, feed);
        }

        #endregion
    }
}
