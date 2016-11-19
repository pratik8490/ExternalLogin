using Acr.UserDialogs;
using ExternalLogin.Context;
using ExternalLogin.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Xamarin.Forms;
using XLabs.Forms.Controls;

namespace ExternalLogin.Pages
{
    public class Register : BasePage
    {
        public Register()
        {
           
            RegisterLayout();
        }

        void RegisterLayout()
        {
            StackLayout slLayout = new StackLayout { VerticalOptions = LayoutOptions.FillAndExpand, HorizontalOptions = LayoutOptions.FillAndExpand, BackgroundColor = LayoutHelper.PageBackgroundColor };
            slLayout.Padding = LayoutHelper.IOSPadding(0, 20, 0, 0);

            ExtendedEntry txtEmail = new ExtendedEntry { Keyboard = Keyboard.Email, Placeholder = "Email", TextColor = Color.Black };

            ExtendedEntry txtUserName = new ExtendedEntry { Keyboard = Keyboard.Email, Placeholder = "Username", TextColor = Color.Black };

            slLayout.Children.Add(txtEmail);
            slLayout.Children.Add(txtUserName);

            Button btnSignUp = new Button
            {
                Text = "Register User",
                TextColor = Color.White,
                BackgroundColor = Color.FromHex("f23e3e")
            };

            btnSignUp.Clicked += (sender, e) =>
            {
                Device.BeginInvokeOnMainThread(async () =>
                {
                    try
                    {
                        btnSignUp.IsVisible = false;
                        if (string.IsNullOrEmpty(txtEmail.Text))
                        {
                            UserDialogs.Instance.ShowError("Please enter email address.");
                            return;
                        }
                        if (string.IsNullOrEmpty(txtUserName.Text))
                        {
                            UserDialogs.Instance.ShowError("Please enter username.");
                            return;
                        }
                        if (Regex.IsMatch(txtEmail.Text.ToString(), Constants.RegxValidation.EmailValidationPattern, RegexOptions.IgnoreCase))
                        {
                            using (UserDialogs.Instance.Loading("Loading..."))
                            {
                                await Services.RegisterExternal(txtUserName.Text, txtEmail.Text);
                            }
                        }
                        else
                        {
                            UserDialogs.Instance.ShowError("Please enter correct format email address.");
                        }
                    }
                    catch (Exception ex)
                    {

                    }
                });
                btnSignUp.IsVisible = true;
            };

            StackLayout slSignUp = new StackLayout
            {
                Children = { btnSignUp },
            };

            slLayout.Children.Add(slSignUp);

            this.Content = new ScrollView
            {
                Content = slLayout
            };
        }
    }
}
