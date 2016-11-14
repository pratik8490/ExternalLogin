using ExternalLogin.Context;
using ExternalLogin.Helper;
using ExternalLogin.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ExternalLogin.Pages
{
    public class BasePage : ContentPage
    {
        public BasePage()
        {
            //Loading Indicatro
        }

        private AuthenticationServices _Services = new AuthenticationServices(Constants.ServiceURL);
        public AuthenticationServices Services
        {
            get { return _Services; }
        }


        #region Override Method
        /// <summary>
        /// On appearing method.
        /// </summary>
        protected override void OnAppearing()
        {
            BindToolbar();
        }
        protected override void OnDisappearing()
        {
            this.ToolbarItems.Clear();
        }
        #endregion

        public void BindToolbar()
        {

            List<ToolbarItem> lstToolbarItem = new List<ToolbarItem>();

            //ExtendedToolbarItem menuToolbarItem = new ExtendedToolbarItem("Menu", Constants.LeftMenuIcon, ToolbarItemOrder.Primary, CategoryMenu);

            lstToolbarItem.Add(new ToolbarItem
            {
                Text = "LogOut",
                Order = ToolbarItemOrder.Secondary,
                Command = new Command(Logout)
            });

            foreach (ToolbarItem item in lstToolbarItem)
            {
                this.ToolbarItems.Add(item);
            }
        }
        private async void Logout()
        {
            ExternalLoginContext.Clear();
            Navigation.PushModalAsync(App.GettingStartPage());
        }
        public void CategoryMenu()
        {
            string ViewName = (ParentView.ParentView).GetType().Name;
            if ((ParentView.ParentView).GetType().Name != "NavigationPage")
                ((MasterDetailPage)(ParentView).ParentView).IsPresented = !((MasterDetailPage)(ParentView).ParentView).IsPresented;
            else
                ((MasterDetailPage)ParentView).IsPresented = !((MasterDetailPage)ParentView).IsPresented;
        }
    }
}
