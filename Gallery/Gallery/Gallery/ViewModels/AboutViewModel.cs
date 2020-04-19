using Gallery.Data;
using Gallery.Services;
using System;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace Gallery.ViewModels {
    public class AboutViewModel : BaseViewModel {
        public AboutViewModel() {
            Title = "About Me";
            OpenWebCommand = new Command(async () => await Browser.OpenAsync("https://www.youtube.com/watch?v=dQw4w9WgXcQ"));
            User = App.CurrentUser;

            if(User != null) {
                if(User.ProfilePicSource != null) {
                    var fileService = DependencyService.Get<FileService>();
                    imageSource = fileService.RetriveImage(User.ProfilePicSource).GetAwaiter().GetResult();
                }
            }
        }

        public User User { get; set; }
        ImageSource imageSource;
        public ImageSource ImageSource {
            get { return imageSource; }
            set { SetProperty(ref imageSource, value); }
        }

        public ICommand OpenWebCommand { get; }

        public async Task SaveImageCommand(Image image, Stream stream) {
            var rnd = new Random();
            var imgId = rnd.NextDouble().ToString();
            User.ProfilePicSource = imgId;
            App.DataContext.Users.Update(User);
            await App.DataContext.SaveChangesAsync();
            var fileSys = DependencyService.Get<FileService>();
            ImageSource = image.Source;
            fileSys.SavePicture(imgId, stream, "temp");
        }
    }
}