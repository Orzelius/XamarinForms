using System;
using System.Collections.Generic;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using Gallery.Models;
using Gallery.ViewModels;

namespace Gallery.Views {
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class NewItemPage : ContentPage {
        private AddItemViewModel viewModel;

        public Item Item { get; set; }

        public NewItemPage() {
            InitializeComponent();

            Item = new Item {
                Text = "Item name",
                Description = "This is an item description."
            };
            BindingContext = viewModel = new AddItemViewModel();

            viewModel.TakePickture().GetAwaiter().GetResult();
        }

        async void Save_Clicked(object sender, EventArgs e) {
            MessagingCenter.Send(this, "AddItem", Item);
            await Navigation.PopModalAsync();
        }

        async void Cancel_Clicked(object sender, EventArgs e) {
            await Navigation.PopModalAsync();
        }
    }
}