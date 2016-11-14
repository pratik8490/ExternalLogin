using ExternalLogin.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ExternalLogin.Pages
{
    public class GettingStart : BasePage
    {
        #region Constructor
        /// <summary>
        /// Initializes a new instances of the ExternalProvider class.
        /// </summary>
        public GettingStart()
        {
            try
            {
                NavigationPage.SetHasNavigationBar(this, false);
                LoadPage();
            }
            catch (Exception ex)
            {

            }
        }
        #endregion

        #region Page Layout
        /// <summary>
        /// LoadPage method for create page layout.
        /// </summary>
        public void LoadPage()
        {
            StackLayout slLayout = new StackLayout { BackgroundColor = LayoutHelper.PageBackgroundColor };
            slLayout.Padding = LayoutHelper.IOSPadding(0, 20, 0, 0);

            Button btnStart = new Button();
            btnStart.Text = "Getting Start";
            btnStart.TextColor = Color.White;
            btnStart.BackgroundColor = LayoutHelper.FacebookButtonColor;

            //btnStart = LayoutHelper.NavButton(btnStart);

            btnStart.Clicked += (sender, e) =>
             {
                 Navigation.PushAsync(App.ExternalProviderListPage());
             };
            var cvBtnLogin = new ContentView
            {
                Padding = new Thickness(10, 5, 10, 10),
                Content = btnStart
            };

            StackLayout slButton = new StackLayout
            {
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.EndAndExpand,
            };

            slButton.Children.Add(btnStart);
            slLayout.Children.Add(slButton);

            ScrollView scrollContent = new ScrollView
            {
                Content = slLayout
            };

            this.Content = scrollContent;
        }
        #endregion
    }
}
