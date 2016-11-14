using System;
using System.Collections.Generic;

using Xamarin.Forms;
using ExternalLogin.Helper;
using ExternalLogin.Droid;
using Xamarin.Forms.Platform.Android;
using WebView = Android.Webkit.WebView;
using ExternalLogin.Services;
using ExternalLogin.Context;

[assembly: ExportRenderer(typeof(ExtendedWebView), typeof(ExtendedWebViewRenderer))]
namespace ExternalLogin.Droid
{
    public class ExtendedWebViewRenderer : WebViewRenderer
    {
        static AuthenticationServices _Services = new AuthenticationServices(Constants.ServiceURL);
        static ExtendedWebView _xwebView = null;
        WebView _webView;

        class ExtendedWebViewClient : Android.Webkit.WebViewClient
        {
            public override async void OnPageFinished(WebView view, string url)
            {
                if (_xwebView != null)
                {
                    int i = 10;
                    while (view.ContentHeight == 0 && i-- > 0) // wait here till content is rendered
                        await System.Threading.Tasks.Task.Delay(100);
                    _xwebView.HeightRequest = view.ContentHeight;

                    ParseUrlForAccessToken(url);
                }
                base.OnPageFinished(view, url);
            }
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.WebView> e)
        {
            base.OnElementChanged(e);
            _xwebView = e.NewElement as ExtendedWebView;
            _webView = Control;

            if (e.OldElement == null)
            {
                _webView.SetWebViewClient(new ExtendedWebViewClient());
            }
        }

        //Login token
        public static async void ParseUrlForAccessToken(string url)
        {
            string fieldName = "access_token=";
            int accessTokenIndex = url.IndexOf(fieldName, StringComparison.Ordinal);
            if (accessTokenIndex > -1)
            {
                int ampersandTokenIndex = url.IndexOf("&", accessTokenIndex, StringComparison.Ordinal);
                string tokenField = url.Substring(accessTokenIndex, ampersandTokenIndex - accessTokenIndex);
                string token = tokenField.Substring(fieldName.Length);
                _Services.AccessToken = token;
                ExternalLoginContext.AccessToken = token;

                //await _Services.GetUserInfo();

                App.TestPage();
            }
        }
    }
}