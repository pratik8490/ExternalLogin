using ExternalLogin.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ExternalLogin.Pages.Master
{
    public class MenuPage : ContentPage
    {
        public ListView Menu { get; set; }

        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="MenuPage"/> class.
        /// </summary>
        public MenuPage()
        {
            try
            {
                //NavigationPage.SetHasNavigationBar(this, false);
                Title = "Menu";
                BackgroundColor = Color.White;
                Icon = Constants.LeftMenuIcon;

                MenuLayout();
            }
            catch (Exception ex)
            {

            }
        }
        #endregion

        /// <summary>
        /// Menu Page Layout.
        /// </summary>
        public void MenuLayout()
        {
            try
            {
                Menu = new MenuListView();

                var menuLabel = new ContentView
                {
                    Padding = new Thickness(10, 36, 0, 5),
                    Content = new Label
                    {
                        TextColor = Color.FromHex("AAAAAA"),
                        Text = "Hello, ",
                    }
                };

                var layout = new StackLayout
                {
                    Spacing = 0,
                    VerticalOptions = LayoutOptions.FillAndExpand
                };
                layout.Children.Add(menuLabel);
                layout.Children.Add(Menu);

                Content = layout;
            }
            catch (Exception ex)
            {

            }
        }
    }
}
