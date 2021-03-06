﻿using Gallery.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Gallery.Views {
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RegisterPage : ContentPage {
        RegisterViewModel viewModel;

        public RegisterPage() {
            InitializeComponent();
            BindingContext = viewModel = new RegisterViewModel();
        }

        private async void Button_Clicked_1(object sender, EventArgs e) {
            bool success = await viewModel.Register();

            if (success) {
                var nav = Navigation.NavigationStack;
                await Navigation.PushModalAsync(new MainPage());
                //for (int x = 0; x < Navigation.NavigationStack.Count() - 1; x++) {
                //    Navigation.RemovePage(Navigation.NavigationStack[x]);
                //}
            }
        }
    }
}