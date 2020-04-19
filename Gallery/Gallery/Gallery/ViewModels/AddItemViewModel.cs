using FFImageLoading.Forms;
using FFImageLoading.Transformations;
using FFImageLoading.Work;
using Gallery.Data;
using Gallery.Services;
using Gallery.Views;
using Plugin.Media;
using Plugin.Media.Abstractions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using ImageSource = Xamarin.Forms.ImageSource;

namespace Gallery.ViewModels {
    class AddItemViewModel : BaseViewModel {
        Stream _stream;

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

        public void Initialyze(Image image, Stream stream) {
            Image = image;
            _stream = stream;
            ImageTitle = DateTime.Now.ToString();
            ImageDesc = "My image";
        }

        public async Task SaveImageCommand() {
            var rnd = new Random();
            var imgId = rnd.NextDouble().ToString();
            await App.DataContext.Posts.AddAsync(new Post() { Description = ImageDesc, Text = ImageTitle, ImageId = imgId, User = App.CurrentUser });
            await App.DataContext.SaveChangesAsync();
            var fileSys = DependencyService.Get<FileService>();

            fileSys.SavePicture(imgId, _stream, "temp"); ;
        }
    }
}
