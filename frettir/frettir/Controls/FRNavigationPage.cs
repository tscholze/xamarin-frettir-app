using System;
using XF.Material.Forms.UI;
using Xamarin.Forms;

namespace frettir.Controls
{
    /// <summary>
    /// Custom subclass of `MaterialNavigationPage`. That is enriched with additional features.
    /// </summary>
    public class FRNavigationPage : MaterialNavigationPage
    {
        #region Init 

        public FRNavigationPage(Page rootPage) : base(rootPage)
        {
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
                Icon = "icon_settings.png"
            };

            ToolbarItems.Add(settings);
        }

        #endregion
    }
}
