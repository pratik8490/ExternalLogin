using Acr.UserDialogs;
using ExternalLogin.Helper;
using ExternalLogin.Models;
using ModernHttpClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using XLabs.Forms.Controls;

namespace ExternalLogin.Pages
{
    public class BrowserLoginView : BasePage
    {
        #region Property
        private ExternalLoginViewModel _selectedProvider = null;
        #endregion

        #region Constructor
        /// <summary>
        /// Initializes a new instances of the Browser Login class.
        /// </summary>
        public BrowserLoginView(ExternalLoginViewModel model)
        {
            try
            {
                using (UserDialogs.Instance.Loading("Loading..."))
                {
                    _selectedProvider = model;
                    PageLayout();
                }
            }
            catch (Exception ex)
            {

            }
        }
        #endregion

        #region Browser Login Layout
        /// <summary>
        /// Page Layout
        /// </summary>
        void PageLayout()
        {
            try
            {
                StackLayout slLayout = new StackLayout { VerticalOptions = LayoutOptions.FillAndExpand, HorizontalOptions = LayoutOptions.FillAndExpand, BackgroundColor = LayoutHelper.PageBackgroundColor };
                slLayout.Padding = LayoutHelper.IOSPadding(0, 20, 0, 0);

                string url = String.Format("{0}{1}", Services.BaseUri, _selectedProvider.Url);

                var hwv = new ExtendedWebView { VerticalOptions = LayoutOptions.FillAndExpand, HorizontalOptions = LayoutOptions.FillAndExpand };

                //var hwv = new HybridWebView { VerticalOptions = LayoutOptions.FillAndExpand, HorizontalOptions = LayoutOptions.FillAndExpand };

                slLayout.Children.Add(hwv);

                hwv.Source = new Uri(url);

                //hwv.RegisterCallback("dataCallback", t =>
                //   Device.BeginInvokeOnMainThread(() =>
                //   {
                //       /**********************************/
                //       //THIS WILL WORK FOR PAGE 1 ONLY
                //       /*********************************/
                //       System.Diagnostics.Debug.WriteLine("!!!!!!!!!!!!!!!!! dataCallback: " + t);
                //   })
                //);

                //hwv.LoadFinished += (s, e) =>
                //{
                //    /***********************************/
                //    //THIS WILL WORK FOR PAGE 1 ONLY
                //    //WEAK REFERENCE LOST???
                //    /***********************************/
                //    ParseUrlForAccessToken(hwv.Uri.ToString());
                //    System.Diagnostics.Debug.WriteLine("(!!!!!!!!!!!!!!!!!!!! LoadFinished");
                //};

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

        private async void ParseUrlForAccessToken(string url)
        {
            const string fieldName = "access_token=";
            int accessTokenIndex = url.IndexOf(fieldName, StringComparison.Ordinal);
            if (accessTokenIndex > -1)
            {
                int ampersandTokenIndex = url.IndexOf("&", accessTokenIndex, StringComparison.Ordinal);
                string tokenField = url.Substring(accessTokenIndex, ampersandTokenIndex - accessTokenIndex);
                string token = tokenField.Substring(fieldName.Length);
                Services.AccessToken = token;

                await TestAuthorization();
            }
        }

        private async Task TestAuthorization()
        {
            string uri = String.Format("{0}/api/Values/1");

            try
            {
                using (HttpClient client = new HttpClient(new NativeMessageHandler()) { BaseAddress = new Uri(Services.BaseUri) })
                {
                    client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue(String.Format("Bearer {0}", Services.AccessToken));
                    HttpResponseMessage response = await client.GetAsync(uri);

                    if (response.IsSuccessStatusCode)
                    {
                        string result = await response.Content.ReadAsStringAsync();
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }

    }
}
