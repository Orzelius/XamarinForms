using System;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Gallery.Views {
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : TabbedPage {
        public MainPage() {
            InitializeComponent();
            if(App.CurrentUser == null) {
                Navigation.PushModalAsync(new NavigationPage(new HomePage()));
            }
        }
    }
}