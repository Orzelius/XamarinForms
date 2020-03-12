using FFImageLoading.Forms;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using Xamarin.Forms;

namespace Gallery.Models {
    public class Item {
        HttpClient Client = new HttpClient();

        public string Id { get; set; }
        public string Text { get; set; }
        public string Description { get; set; }
        public object ImageSource { get; set; }
    }
}