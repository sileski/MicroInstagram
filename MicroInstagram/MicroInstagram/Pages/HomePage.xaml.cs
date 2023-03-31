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
    public partial class HomePage : ContentPage
    {
        HomeViewModel viewModel;
        public HomePage()
        {
            InitializeComponent();

            viewModel = new HomeViewModel();
            this.BindingContext = viewModel;
        }

        private void ImagesList_ItemAppearing(object sender, ItemVisibilityEventArgs e)
        {
            viewModel.LoadMoreData(e);
        }
    }
}
