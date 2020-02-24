using Authorizator.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq.Expressions;
using System.Text;

namespace Authorizator.ViewModels {
    class MainViewModel : INotifyPropertyChanged {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string name) {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public MainViewModel() {
            _users = App.Database.GetAsync().GetAwaiter().GetResult();
        }


        private List<User> _users;
        public List<User> Users {
            get { return _users; }
            set {
                if (value != _users) {
                    _users = value;
                    OnPropertyChanged(nameof(Users));
                }
            }
        }

        private User _loggedInUser;
        public User LoggedInUser {
            get { return _loggedInUser; }
            set {
                if (value != _loggedInUser) _loggedInUser = value;
                OnPropertyChanged(nameof(LoggedInUser));
            }
        }

    }
}
