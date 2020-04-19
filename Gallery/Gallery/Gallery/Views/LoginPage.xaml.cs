using Gallery.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Gallery.Views {
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage {
        LoginViewModel viewModel;

        public LoginPage() {
            BindingContext = viewModel = new LoginViewModel();
            InitializeComponent();
        }

        private async void Button_Clicked_1(object sender, EventArgs e) {
            bool success = await viewModel.Login();

            if (success) {
                await Navigation.PushModalAsync(new MainPage());
            }
        }
    }
}