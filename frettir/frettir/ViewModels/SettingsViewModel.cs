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
           // Title = "Settings";

            AddNewFeedCommand = new Command<string>(AddNewFeed);
        }

        void AddNewFeed(string urlString)
        {
            if (!UriHelper.IsValidUrl(urlString))
            {
                return;
            }

            var posts = WordpressService.GetPosts(urlString);

            foreach (var p in posts)
            {
                Console.WriteLine(p.Title);
            }
        }
    }
}
