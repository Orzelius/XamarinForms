using System;
using System.Collections.Generic;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using Gallery.Models;
using Gallery.ViewModels;
using Plugin.Media;
using Plugin.Media.Abstractions;

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

            TakePicture();
        }

        public async void TakePicture() {

      
            await CrossMedia.Current.Initialize();

            Image image = new Image();

            if (!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsTakePhotoSupported) {
                //DisplayAlert("No Camera", ":( No camera available.", "OK");
                return;
            }

            var file = await CrossMedia.Current.TakePhotoAsync(new StoreCameraMediaOptions {
                Directory = "Test",
                SaveToAlbum = true,
                CompressionQuality = 75,
                CustomPhotoSize = 50,
                PhotoSize = PhotoSize.MaxWidthHeight,
                MaxWidthHeight = 2000,
                DefaultCamera = CameraDevice.Front
            });

            if(file == null) {
                TakePicture();
            }


            image.Source = ImageSource.FromStream(() =>
            {
                var stream = file.GetStream();
                return stream;
            });

            viewModel.Initialyze(image);
        }

        async void Save_Clicked(object sender, EventArgs e) {
            await viewModel.SaveImageCommand();
            await Navigation.PopModalAsync();
        }

        async void Cancel_Clicked(object sender, EventArgs e) {
            await Navigation.PopModalAsync();
        }
    }
}