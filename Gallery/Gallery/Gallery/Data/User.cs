using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Xamarin.Forms;

namespace Gallery.Data {
    public class User {
        [Key]
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string ProfilePicSource { get; set; }
        public List<Post> Posts { get; set; }

        public override string ToString() {
            return Username;
        }
    }
}
