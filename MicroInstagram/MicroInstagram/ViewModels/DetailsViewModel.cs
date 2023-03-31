using MicroInstagram.Models;
using MicroInstagram.Pages;
using MicroInstagram.Services;
using System.Windows.Input;
using Xamarin.Forms;

namespace MicroInstagram.ViewModels
{
    class DetailsViewModel : BaseViewModel
    {
        private int selectedImageIndex;
        public ImageModel Image { get; set; }

        private readonly IImagesApiService imagesApiService = DependencyService.Get<IImagesApiService>();
        private readonly IMessageService messageService = DependencyService.Get<IMessageService>();

        public ICommand SaveChangesCommand => new Command(SaveChanges);
        public ICommand DeleteImageCommand => new Command(DeleteImageDialog);
        public ICommand OpenFullImageCommand => new Command(NavigateToFullScreenImagePage);

        public DetailsViewModel(ImageModel image, int selectedImageIndex)
        {
            this.Image = image;
            this.selectedImageIndex = selectedImageIndex;
        }

        private async void SaveChanges()
        {
            if (Validation())
            {
                Result<ImageModel> imagesResult = await imagesApiService.UpdateImageDetails(Image);
                if (imagesResult is Result<ImageModel>.Success)
                {
                    Images[selectedImageIndex] = imagesResult.Data;
                    await Application.Current.MainPage.Navigation.PopAsync();
                    messageService.Show("Changes saved");
                }
                else if (imagesResult is Result<ImageModel>.Failure)
                {
                    await Application.Current.MainPage.DisplayAlert("Error", imagesResult.Error, "OK");
                }
            }
        }

        private async void DeleteImageDialog()
        {
            bool delete = await Application.Current.MainPage.DisplayAlert("Delete Image", "Are you sure?", "Delete", "Cancel");
            if (delete)
            {
                DeleteImage();
            }
        }

        private async void DeleteImage()
        {
            Result<object> imagesResult = await imagesApiService.DeleteImage(Image.Id);
            if (imagesResult is Result<object>.Success)
            {
                Images.Remove(Image);
                await Application.Current.MainPage.Navigation.PopAsync();
                messageService.Show("Image deleted");
            }
            else if (imagesResult is Result<object>.Failure)
            {
                await Application.Current.MainPage.DisplayAlert("Error", imagesResult.Error, "OK");
            }
        }

        public bool Validation()
        {
            if (string.IsNullOrEmpty(Image.Title))
            {
                Application.Current.MainPage.DisplayAlert("Error", "Title can't be empty", "OK");
                return false;
            }
            return true;
        }

        private void NavigateToFullScreenImagePage()
        {
            Application.Current.MainPage.Navigation.PushAsync(new FullScreenImagePage(Image));
        }
    }
}
