using FFImageLoading.Forms;
using System;
using System.ComponentModel.DataAnnotations;
using System.Net.Http;
using System.Net.Http.Headers;
using Xamarin.Forms;

namespace Gallery.Data {
    public class Post {
        [Key]
        public int Id { get; set; }
        public string Text { get; set; }
        public string Description { get; set; }
        public string ImageId { get; set; }
        public User User { get; set; }
    }
    public class PostListModel : Post {
        public ImageSource Image { get; set; }
    }
}