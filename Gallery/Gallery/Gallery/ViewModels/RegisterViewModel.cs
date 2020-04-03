using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Gallery.ViewModels {
    class RegisterViewModel : BaseViewModel {

        public ObservableCollection<string> errors { get; set; }

        string _password;
        public string Password {
            get { return _password; }
            set { SetProperty(ref _password, value); }
        }

        string _password2;
        public string Password2 {
            get { return _password2; }
            set { SetProperty(ref _password2, value); }
        }

        string _username;
        public string Username {
            get { return _username; }
            set { SetProperty(ref _username, value); }
        }

        public void Initialyze() {
            _password = "";
            _password2 = "";
            _username = "";
        }

        public async Task RegisterCommand() {
            errors.Clear();
            if(_password == "" || _password2 == "" || _username == "") {
                errors.Add("Password or username can't  be empty");
                return;
            }

            if (_password != Password2)
                errors.Add("Passwords do not match");
            if(App.DataContext.Users.FirstOrDefaultAsync(u => u.Username == _username) != null)
                errors.Add("Username already taken");

            if(errors.Count != 0) {
                return;
            }

            await App.DataContext.Users.AddAsync(new Data.User() { Password = _password, Username = _username });
        }
    }
}
