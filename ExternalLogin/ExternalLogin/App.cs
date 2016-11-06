using ExternalLogin.Models;
using ExternalLogin.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace ExternalLogin
{
    public class App : Application
    {
        public App()
        {
            // The root page of your application
            MainPage = ExternalProviderListPage();
        }

        public static Page ExternalProviderListPage()
        {
            return new ExternalProvidersList();
        }

        public static Page BrowserLoginViewPage(ExternalLoginViewModel model)
        {
            return new BrowserLoginView(model);
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
