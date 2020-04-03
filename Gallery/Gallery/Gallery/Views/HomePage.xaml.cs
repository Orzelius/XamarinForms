using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Gallery.Views {
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomePage : ContentPage {
        public HomePage() {
            InitializeComponent();
        }

        async void OnLoginClicked(object sender, EventArgs args) {
            //await Navigation.PushAsync(new LoginPage());
        }
        async void OnRegisterClicked(object sender, EventArgs args) {
            await Navigation.PushAsync(new RegisterPage());
        }
    }
}