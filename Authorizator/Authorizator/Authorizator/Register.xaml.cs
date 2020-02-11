using Authorizator.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Authorizator {
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Register : ContentPage {
        Random rnd = new Random();
        public Register() {
            InitializeComponent();
        }

        private async void RegisterClicked(object sender, EventArgs e) {
            ErrorMsg.IsVisible = false;
            if (Pw1.Text != Pw2.Text) {
                ErrorMsg.IsVisible = true;
                ErrorMsg.Text = "Passwords don't match";
                return;
            }
            if (string.IsNullOrEmpty(Username.Text)) {
                ErrorMsg.IsVisible = true;
                ErrorMsg.Text = "Username can't be empty";
                return;
            }
            if (string.IsNullOrEmpty(Pw1.Text)) {
                ErrorMsg.IsVisible = true;
                ErrorMsg.Text = "Password can't be empty";
                return;
            }
            var user = App.Database.GetAsync().GetAwaiter().GetResult().Find(u => u.Username == Username.Text);
            if (user != null) {
                ErrorMsg.IsVisible = true;
                ErrorMsg.Text = "Username already taken";
                return;
            }

            await App.Database.SaveAsync(new User() { Password = Pw1.Text, Username = Username.Text });
            var users = App.Database.GetAsync().GetAwaiter().GetResult();
            App.CurrentUser = users.FirstOrDefault(u => u.Username == Username.Text);
            await Navigation.PopAsync();
        }
    }
}