using Authorizator.Data;
using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Authorizator {
    public partial class App : Application {

        static UserDb database;
        public static User CurrentUser;
        public static UserDb Database {
            get {
                if (database == null) {
                    database = new UserDb(Path.Combine(Environment.GetFolderPath
                (Environment.SpecialFolder.LocalApplicationData), "User2.db3"));
                }
                return database;
            }
        }

        public App() {
            InitializeComponent();

            MainPage = new NavigationPage(new MainPage());
        }

        protected override void OnStart() {
        }

        protected override void OnSleep() {
        }

        protected override void OnResume() {
        }
    }
}
