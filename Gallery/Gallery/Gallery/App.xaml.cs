using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Gallery.Views;
using Gallery.Data;
using System.IO;
using Gallery.Services;

namespace Gallery {
    public partial class App : Application {

        public static User CurrentUser;
        static DatabaseContext database;
        public static DatabaseContext DataContext {
            get {
                return database;
            }
        }

        static string path;
        public static string Path {
            get {
                return path;
            }
        }

        public App(string dbPath) {
            InitializeComponent();

            path = dbPath;

            database = new DatabaseContext(dbPath);
            //database.Database.EnsureDeleted();
            database.Database.EnsureCreated();
            DependencyService.Register<FileService>();
            MainPage = new MainPage();
        }

        protected override void OnStart() {
        }

        protected override void OnSleep() {
        }

        protected override void OnResume() {
        }
    }
}
