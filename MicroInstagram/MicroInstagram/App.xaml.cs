using MicroInstagram.Pages;
using MicroInstagram.Services;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MicroInstagram
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            DependencyService.Register<IImagesApiService, ImagesApiService>();
            MainPage = new NavigationPage(new HomePage());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
