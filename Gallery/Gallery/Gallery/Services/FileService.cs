using Gallery.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;
using Xamarin.Forms;

namespace Gallery.Services {
    public class FileService {
        public void SavePicture(string name, Stream data, string location = "temp") {
            var documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            documentsPath = Path.Combine(documentsPath, "Orders", location);
            Directory.CreateDirectory(documentsPath);

            string filePath = Path.Combine(documentsPath, name);

            byte[] bArray = new byte[data.Length];
            using (FileStream fs = new FileStream(filePath, FileMode.OpenOrCreate)) {
                using (data) {
                    data.Read(bArray, 0, (int)data.Length);
                }
                int length = bArray.Length;
                fs.Write(bArray, 0, length);
            }
        }

        public async System.Threading.Tasks.Task<ImageSource> RetriveImage(string id) {
            var documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            documentsPath = Path.Combine(documentsPath, "Orders", "temp");
            Directory.CreateDirectory(documentsPath);

            string filePath = Path.Combine(documentsPath, id);

            //foreach (var file in System.IO.Directory.GetFiles(documentsPath)) {//Because you cannot delete a non-empty directory
            //    var filetext = file;
            //}

            var memoryStream = new MemoryStream();

            using (var source = System.IO.File.OpenRead(filePath)) {
                await source.CopyToAsync(memoryStream);
            }


            var stream = ImageSource.FromStream(() => memoryStream);
            return stream;
        }
    }
}
