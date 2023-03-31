using MicroInstagram.Models;
using MicroInstagram.Services;
using System.IO;
using System.Windows.Input;
using Xamarin.Forms;

namespace MicroInstagram.ViewModels
{
    class AddNewImageViewModel : BaseViewModel
    { 
        private Stream imageStream;
        public string Title { get; set; }
        private ImageSource selectedImage;
        public ImageSource SelectedImage
        {
            get
            {
                return selectedImage;
            }
            set
            {
                selectedImage = value;
                RaisePropertyChanged();
            }
        }

        private readonly IImagePickerService imagePickerService = DependencyService.Get<IImagePickerService>();
        private readonly IImagesApiService imagesApiService = DependencyService.Get<IImagesApiService>();
        private readonly IMessageService messageService = DependencyService.Get<IMessageService>();

        public ICommand SelectImageCommand => new Command(SelectImageAsync);
        public ICommand SaveImageCommand => new Command(SaveImage);

        public AddNewImageViewModel()
        {
        }

        public async void SelectImageAsync()
        {
            Stream stream = await imagePickerService.GetImageStreamAsync();
            if (stream != null)
            {
                SelectedImage = ImageSource.FromStream(() => stream);
                imageStream = stream;
            }
        }

        public async void SaveImage()
        {
            if (Validation())
            {
                ImageRequest imageRequest = new ImageRequest(Title);
                Result<ImageModel> addImageResult = await imagesApiService.AddNewImage(imageRequest, imageStream);
                if (addImageResult is Result<ImageModel>.Success)
                {
                    Images.Insert(0, addImageResult.Data);
                    await Application.Current.MainPage.Navigation.PopAsync();
                    messageService.Show("Added new image");
                }
                else if (addImageResult is Result<ImageModel>.Failure)
                {
                    await Application.Current.MainPage.DisplayAlert("Error", addImageResult.Error, "OK");
                }
            }
        }

        public bool Validation()
        {
            if (SelectedImage == null)
            {
                Application.Current.MainPage.DisplayAlert("Error", "Please select image", "OK");
                return false;
            }
            else if (string.IsNullOrEmpty(Title))
            {
                Application.Current.MainPage.DisplayAlert("Error", "Please enter title", "OK");
                return false;
            }
            return true;
        }
    }
}
