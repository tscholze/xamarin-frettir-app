using System.Windows.Input;
using frettir.Utils;
using Xamarin.Forms;

namespace frettir.ViewModels
{
    public class EmptyViewModel: BaseViewModel
    {
        #region Public properties

        /// <summary>
        /// Gets the show settings page command.
        /// </summary>
        /// <value>The show settings page command.</value>
        public ICommand ShowSettingsPageCommand { get; }

        #endregion

        #region Init

        /// <summary>
        /// Initializes a new instance of the <see cref="T:frettir.ViewModels.EmptyViewModel"/> class.
        /// </summary>
        public EmptyViewModel()
        {
            ShowSettingsPageCommand = new Command(ShowSettingsPage);
        }

        #endregion

        #region Private helper

        /// <summary>
        /// Requests to show the settings page.
        /// </summary>
        void ShowSettingsPage()
        {
            MessagingCenter.Send(Application.Current, Constants.NOTIFICATION_ID_SHOW_SETTINGS_PAGE);
        }

        #endregion
    }
}
