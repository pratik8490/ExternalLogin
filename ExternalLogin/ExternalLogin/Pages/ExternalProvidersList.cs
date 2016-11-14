using Acr.UserDialogs;
using ExternalLogin.Helper;
using ExternalLogin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using XLabs.Forms.Controls;

namespace ExternalLogin.Pages
{
    public class ExternalProvidersList : BasePage
    {
        #region Property
        private List<ExternalLoginViewModel> externalLoginProviders = new List<ExternalLoginViewModel>();
        private ExternalLoginViewModel _selectedProvider = null;
        #endregion

        #region Constructor
        /// <summary>
        /// Initializes a new instances of the ExternalProvider class.
        /// </summary>
        public ExternalProvidersList()
        {
            try
            {
                NavigationPage.SetHasNavigationBar(this, false);

                Device.BeginInvokeOnMainThread(async () =>
                {
                    using (UserDialogs.Instance.Loading("Loading..."))
                    {
                        externalLoginProviders = new List<ExternalLoginViewModel>(await Services.GetExternalLoginProviders());
                        LoadPage();
                    }
                });
            }
            catch (Exception ex)
            {

            }
        }

        #endregion

        #region Override method
        protected override void OnAppearing()
        {
            //Check internet connection
        }
        #endregion

        #region Page Layout
        /// <summary>
        /// LoadPage method for create page layout.
        /// </summary>
        public void LoadPage()
        {
            try
            {
                StackLayout slLayout = new StackLayout { BackgroundColor = LayoutHelper.PageBackgroundColor };
                slLayout.Padding = LayoutHelper.IOSPadding(0, 20, 0, 0);

                int index = 0;
                foreach (ExternalLoginViewModel model in externalLoginProviders)
                {
                    int localIndex = index;

                    Button button = new Button();
                    button.Text = model.Name;
                    button.TextColor = Color.White;
                    button.BackgroundColor = LayoutHelper.FacebookButtonColor;

                    button.Clicked += (object sender, EventArgs e) =>
                    {
                        _selectedProvider = externalLoginProviders[localIndex];
                        //Navigate to browser page
                        Navigation.PushAsync(App.BrowserLoginViewPage(_selectedProvider));
                    };

                    var cvBtnLogin = new ContentView
                    {
                        Padding = new Thickness(10, 5, 10, 10),
                        Content = button
                    };

                    index++;

                    slLayout.Children.Add(cvBtnLogin);
                }

                ScrollView scrollContent = new ScrollView
                {
                    Content = slLayout
                };

                this.Content = scrollContent;
            }
            catch (Exception ex)
            {

            }
        }
        #endregion

    }
}
