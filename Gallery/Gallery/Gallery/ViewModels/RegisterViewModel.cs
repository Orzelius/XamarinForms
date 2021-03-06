﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Gallery.ViewModels {
    public class RegisterViewModel : BaseViewModel {
        public ICommand RegisterCommand { get; set; }

        public RegisterViewModel() {
            RegisterCommand = new Command(
            execute: async () => {
                Console.WriteLine("This is execute of toggleCompassCmd!");
                await Register();
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

        public async Task<bool> Register() {
            Error = "";
            if (String.IsNullOrEmpty(_password) || String.IsNullOrEmpty(_password2) || String.IsNullOrEmpty(_username)) {
                Error = "Password or username can't  be empty";
                return false;
            }
            if (_password != Password2) {
                Error = "Passwords do not match";
                return false;
            }
            if (await App.DataContext.Users.FirstOrDefaultAsync(u => u.Username == _username) != null) {
                Error = "Username already taken";
                return false;
            }

            if (Error != "")
                return false;
            
            await App.DataContext.Users.AddAsync(new Data.User() { Password = _password, Username = _username });
            await App.DataContext.SaveChangesAsync();
            App.CurrentUser = await App.DataContext.Users.FirstOrDefaultAsync(u => u.Username == _username);
            return true;
        }
    }
}
