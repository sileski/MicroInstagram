using Android.Widget;
using MicroInstagram.Droid.Services;
using MicroInstagram.Services;
using Xamarin.Forms;

[assembly: Dependency(typeof(MessageServiceAndroid))]
namespace MicroInstagram.Droid.Services
{
    public class MessageServiceAndroid : IMessageService
    {
        public void Show(string message)
        {
            var toast = Toast.MakeText(Android.App.Application.Context, message, ToastLength.Long);
            toast.Show();
        }
    }
}