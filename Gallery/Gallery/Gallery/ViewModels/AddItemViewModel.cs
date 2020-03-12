using Gallery.Models;
using Gallery.Views;
using Plugin.Media;
using Plugin.Media.Abstractions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Gallery.ViewModels {
    class AddItemViewModel : BaseViewModel {
        Image image;
        public Image Image {
            get { return image; }
            set { SetProperty(ref image, value); }
        }

        string title;
        public string ImageTitle {
            get { return title; }
            set { SetProperty(ref title, value); }
        }

        string desc;
        public string ImageDesc {
            get { return desc; }
            set { SetProperty(ref desc, value); }
        }

        public void Initialyze(Image image) {
            Image = image;

            ImageTitle = DateTime.Now.ToString();
            ImageDesc = "My image";
        }

        public async Task SaveImageCommand() {
            await DataStore.AddItemAsync(new Models.Item() { Description = ImageDesc, Text = ImageTitle, ImageSource = image.Source });
        }
    }
}
