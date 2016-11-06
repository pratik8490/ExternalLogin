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
    }
}
