using Authorizator.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Authorizator {
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage {
        public MainPage() {
            InitializeComponent();

            //BindingContext = this;
        }
        protected async override void OnAppearing() {
            base.OnAppearing();

            if (App.CurrentUser != null) {
                LoggedInMsg.Text = "Logged in as " + App.CurrentUser.Username;
                LogoutButton.IsVisible = true;
                LoginBtn.IsVisible = false;
                RegisterBtn.IsVisible = false;
            }
        }
        async void OnLoginClicked(object sender, EventArgs args) {
            await Navigation.PushAsync(new Login());
        }
        async void OnRegisterClicked(object sender, EventArgs args) {
            await Navigation.PushAsync(new Register());
        }
        void OnLogoutClicked(object sender, EventArgs args) {
            App.CurrentUser = null;
            LoggedInMsg.Text = "You are not logged in";
            LogoutButton.IsVisible = false;
            LoginBtn.IsVisible = true;
            RegisterBtn.IsVisible = true;
        }
    }
}
