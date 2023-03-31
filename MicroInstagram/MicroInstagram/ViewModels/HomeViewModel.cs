using MicroInstagram.Models;
using MicroInstagram.Pages;
using MicroInstagram.Services;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Input;
using Xamarin.Forms;

namespace MicroInstagram.ViewModels
{
    class HomeViewModel : BaseViewModel
    {
        private const int PageLimit = 10;
        private int currentPage = 0;
        private readonly IImagesApiService imagesApiService = DependencyService.Get<IImagesApiService>();

        private bool isLoading = false;
        public bool IsLoading
        {
            get
            {
                return isLoading;
            }
            set
            {
                isLoading = value;
                RaisePropertyChanged();
            }
        }

        public ICommand LoadMoreDataCommand => new Command<ItemVisibilityEventArgs>(LoadMoreData);
        public ICommand NavigateToDetailsCommand => new Command(NavigateToDetailsPage);
        public ICommand NavigateToNewImageCommand => new Command(NavigateToNewImagePage);

        public HomeViewModel()
        {
            GetImages();
        }

        private async void GetImages()
        {
            IsLoading = true;
            Result<List<ImageModel>> imagesResult = await imagesApiService.GetPhotos(currentPage, PageLimit);
            if (imagesResult is Result<List<ImageModel>>.Success)
            {
                imagesResult.Data.ForEach(image =>
                {
                    Images.Add(image);
                });
                IsLoading = false;
            } 
            else if(imagesResult is Result<List<ImageModel>>.Failure)
            {
                IsLoading = false;
                await Application.Current.MainPage.DisplayAlert("Error", imagesResult.Error, "OK");
            }
        }

        public void LoadMoreData(ItemVisibilityEventArgs e)
        {
            ImageModel item = e.Item as ImageModel;
            if (item == Images[Images.Count - 1])
            {
                currentPage += PageLimit;
                GetImages();
            }
        }

        private void NavigateToDetailsPage(object o)
        {
            ImageModel image = o as ImageModel;
            int index = Images.IndexOf(image);
            Application.Current.MainPage.Navigation.PushAsync(new DetailsPage(image, index));
        }

        private void NavigateToNewImagePage()
        {
            Application.Current.MainPage.Navigation.PushAsync(new AddNewImagePage());
        }
    }
}
