using Gallery.ViewModels;
using Plugin.Media;
using Plugin.Media.Abstractions;
using System;
using System.ComponentModel;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Gallery.Views {
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class AboutPage : ContentPage {
        private AboutViewModel viewModel;

        public AboutPage() {
            InitializeComponent();
            BindingContext = viewModel = new AboutViewModel();
        }

        private async void Button_Clicked(object sender, EventArgs e) {
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

            if (file == null) {
                return;
            }

            Stream stream;
            image.Source = ImageSource.FromStream(() => {
                stream = file.GetStream();
                return stream;
            });

            await viewModel.SaveImageCommand(image, file.GetStream());
        }
    }
}