using MicroInstagram.Models;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace MicroInstagram.ViewModels
{
    public abstract class BaseViewModel : INotifyPropertyChanged
    {
        private SharedData sharedData;

        public event PropertyChangedEventHandler PropertyChanged;

        public ObservableCollection<ImageModel> Images
        {
            get
            {
                return sharedData.Images;
            }
            set
            {
                sharedData.Images = value;
                RaisePropertyChanged();
            }
        }

        public BaseViewModel()
        {
            sharedData = SharedData.Instance;
        }

        protected void RaisePropertyChanged([CallerMemberName] string caller = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(caller));
            }
        }
    }
}
