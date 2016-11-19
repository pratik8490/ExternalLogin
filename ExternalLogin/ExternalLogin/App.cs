using ExternalLogin.Helper;
using ExternalLogin.Models;
using ExternalLogin.Pages;
using ExternalLogin.Pages.Master;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace ExternalLogin
{
    public class App : Application
    {
        static NavigationPage navPage;

        public App()
        {
            // The root page of your application
            MainPage = GettingStartPage();
        }
        public static Page GettingStartPage(bool firstTime = false)
        {
            if (!firstTime)
            {
                navPage = new NavigationPage(new GettingStart());
                navPage.BarBackgroundColor = Constants.BarBackGroundColor;
                navPage.BarTextColor = Constants.BarBackTextColor;
                return navPage;
            }
            else
            {
                return new GettingStart();
            }
        }
        public static Page ExternalProviderListPage()
        {
            return new ExternalProvidersList();
        }

        public static Color BarTextColor()
        {
            return Color.White;
        }

        public static Page BrowserLoginViewPage(ExternalLoginViewModel model)
        {
            return new BrowserLoginView(model);
        }

        public static Page TestPage()
        {
            return new Register();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
