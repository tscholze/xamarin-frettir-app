using System;
using XF.Material.Forms.UI;
using Xamarin.Forms;
using System.Windows.Input;
using frettir.Utils;

namespace frettir.Controls
{
    /// <summary>
    /// Custom subclass of `MaterialNavigationPage`. That is enriched with additional features.
    /// </summary>
    public class FRNavigationPage : MaterialNavigationPage
    {
        #region Private properties

        /// <summary>
        /// Gets the show settings page command.
        /// </summary>
        /// <value>The show settings page command.</value>
        ICommand ShowSettingsPageCommand { get; }

        #endregion

        #region Init 

        public FRNavigationPage(Page rootPage) : base(rootPage)
        {
            ShowSettingsPageCommand = new Command(ShowSettingsPage);
            SetupToolbarItems();
        }

        #endregion

        #region Private helper

        /// <summary>
        /// Setups the always visisble but customized toolbar items.
        /// </summary>
        void SetupToolbarItems()
        {
            var settings = new ToolbarItem
            {
                Icon = "icon_settings.png",
                Command = ShowSettingsPageCommand
            };

            ToolbarItems.Add(settings);
        }

        /// <summary>
        /// Requests to show the settings page.
        /// </summary>
        void ShowSettingsPage()
        {
            MessagingCenter.Send(this, Constants.NOTIFICATION_ID_SHOW_SETTINGS_PAGE);
        }

        #endregion
    }
}
