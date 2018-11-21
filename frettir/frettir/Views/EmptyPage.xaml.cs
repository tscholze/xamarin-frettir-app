using frettir.ViewModels;
using Xamarin.Forms;

namespace frettir.Views
{
    public partial class EmptyPage : ContentPage
    {
        #region Init

        public EmptyPage()
        {
            InitializeComponent();
            BindingContext = new EmptyViewModel();
        }

        #endregion
    }
}