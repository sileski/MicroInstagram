using MicroInstagram.Models;
using System.Collections.ObjectModel;

namespace MicroInstagram.ViewModels
{
    public class SharedData
    {
        private static SharedData instance;
        public static SharedData Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new SharedData();
                }
                return instance;
            }
        }

        private ObservableCollection<ImageModel> images = new ObservableCollection<ImageModel>();
        public ObservableCollection<ImageModel> Images
        {
            get
            {
                return images;
            }
            set
            {
                images = value;
            }
        }

        private SharedData() { }
    }
}
