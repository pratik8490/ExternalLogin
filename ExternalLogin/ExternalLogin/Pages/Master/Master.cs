using ExternalLogin.Context;
using ExternalLogin.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ExternalLogin.Pages.Master
{
    public class Master : MasterDetailPage
    {
        MenuPage menuPage;

        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="Master Page"/> class.
        /// </summary>
        public Master(ContentPage DetailPage)
        {
            menuPage = new MenuPage();

            Master = menuPage;

            //this.Master = new MenuPage { Icon = Constants.ImagePath.CategoryLineMenuIcon };
            this.Detail = DetailPage;
        }
        #endregion

        protected override void OnDisappearing()
        {
            GC.Collect();
        }
        void NavigateTo(MenuItem menu)
        {
            if (menu == null)
                return;


            //API call for remove deviceID
            //Clear function
            ExternalLoginContext.Clear();
            Navigation.PushModalAsync(App.GettingStartPage(true));

            //Page displayPage = (Page)Activator.CreateInstance(menu.TargetType);

            //Detail = new NavigationPage(displayPage);

            //menuPage.Menu.SelectedItem = null;
            //IsPresented = false;
        }
    }
}