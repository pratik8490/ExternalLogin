using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using XLabs.Ioc;
using XLabs.Serialization;
using XLabs.Serialization.JsonNET;
using Acr.UserDialogs;

namespace ExternalLogin.Droid
{
    [Activity(Label = "ExternalLogin", Icon = "@drawable/icon", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsApplicationActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            global::Xamarin.Forms.Forms.Init(this, bundle);
            UserDialogs.Init(() => (Activity)Xamarin.Forms.Forms.Context);

            if (!Resolver.IsSet)
            {
                this.SetIoc();
            }

            LoadApplication(new App());
        }

        /// <summary>
        /// Sets the Ioc.
        /// </summary>
        private void SetIoc()
        {
            var resolverContainer = new SimpleContainer();

            resolverContainer.Register<IJsonSerializer, JsonSerializer>();
            Resolver.SetResolver(resolverContainer.GetResolver());
        }
    }
}

