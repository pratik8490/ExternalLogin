using ExternalLogin.Context;
using ExternalLogin.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ExternalLogin.Pages
{
    public class test : BasePage
    {
        public test()
        {
            TestLayout();
        }

        void TestLayout()
        {
            StackLayout slLayout = new StackLayout { VerticalOptions = LayoutOptions.FillAndExpand, HorizontalOptions = LayoutOptions.FillAndExpand, BackgroundColor = LayoutHelper.PageBackgroundColor };
            slLayout.Padding = LayoutHelper.IOSPadding(0, 20, 0, 0);

            Label lblToken = new Label
            {
                Text = ExternalLoginContext.AccessToken,
                TextColor = Color.Black
            };

            slLayout.Children.Add(lblToken);

            this.Content = new ScrollView
            {
                Content = slLayout
            };
        }
    }
}
