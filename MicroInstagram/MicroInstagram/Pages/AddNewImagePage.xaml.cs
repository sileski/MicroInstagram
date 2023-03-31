using MicroInstagram.ViewModels;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MicroInstagram.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddNewImagePage : ContentPage
    {
        public string ImageTitle { get; set; }

        public AddNewImagePage()
        {
            InitializeComponent();
            this.BindingContext = new AddNewImageViewModel();
        }
    }
}
