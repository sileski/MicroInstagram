using MicroInstagram.Models;
using MicroInstagram.ViewModels;
using Xamarin.Forms;

namespace MicroInstagram.Pages
{
    public partial class DetailsPage : ContentPage
    {
        public DetailsPage(ImageModel image, int selectedImageIndex)
        {
            InitializeComponent();
            this.BindingContext = new DetailsViewModel(image, selectedImageIndex);
        }
    }
}
