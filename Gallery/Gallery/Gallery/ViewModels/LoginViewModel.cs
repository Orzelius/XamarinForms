using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Gallery.ViewModels {
    class LoginViewModel: BaseViewModel {
        public ICommand RegisterCommand { get; set; }

        public LoginViewModel() {
            RegisterCommand = new Command(
            execute: async () => {
                Console.WriteLine("This is execute of toggleCompassCmd!");
                await Login();
            },
            canExecute: () => {
                return true;
            });

            //Initialyze();
        }

        string _error;
        public string Error {
            get { return _error; }
            set { SetProperty(ref _error, value); }
        }

        string _password;
        public string Password {
            get { return _password; }
            set { SetProperty(ref _password, value); }
        }

        string _username;
        public string Username {
            get { return _username; }
            set { SetProperty(ref _username, value); }
        }

        public void Initialyze() {
            _password = "";
            _username = "";
        }

        public async Task<bool> Login() {
            Error = "";
            if (String.IsNullOrEmpty(_password) || String.IsNullOrEmpty(_username)) {
                Error = "Password or username can't  be empty";
                return false;
            }
            var user = await App.DataContext.Users.FirstOrDefaultAsync(u => u.Username == _username && u.Password == _password);
            if (user == null) {
                Error = "Incorrect password or username";
                return false;
            }

            App.CurrentUser = user;
            return true;
        }
    }
}
