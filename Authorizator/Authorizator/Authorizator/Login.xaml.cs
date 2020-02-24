using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Authorizator {
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Login : ContentPage {
        public Login() {
            InitializeComponent();
        }

        private async void LoginClicked(object sender, EventArgs e) {
            if (Pw.Text != null && Username.Text != null && Pw.Text.Length > 0 && !string.IsNullOrEmpty(Username.Text)) {
                var users = await App.Database.GetAsync();
                var user = users.FirstOrDefault(u => u.Username == Username.Text && u.Password == Pw.Text);
                if(user != null) {
                    App.CurrentUser = user;
                    InvalidPw.IsVisible = false;
                    await Navigation.PopAsync();
                }
                InvalidPw.IsVisible = true;
            }
            else {

            }
        }
    }
}