using MicroInstagram.Models;
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
    public partial class FullScreenImagePage : ContentPage
    {
        public FullScreenImagePage(ImageModel image)
        {
            InitializeComponent();
            this.BindingContext = new FullScreenImageViewModel(image);
        }
    }
}
