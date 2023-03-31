using MicroInstagram.iOS.Services;
using MicroInstagram.Services;
using Xamarin.Forms;

[assembly: Dependency(typeof(MessageServiceIos))]
namespace MicroInstagram.iOS.Services
{
    class MessageServiceIos : IMessageService
    {
        public void Show(string message)
        {
            App.Current.MainPage.DisplayAlert("Info", message, "OK");
        }
    }
}