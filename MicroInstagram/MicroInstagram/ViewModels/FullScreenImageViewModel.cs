using MicroInstagram.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MicroInstagram.ViewModels
{
    class FullScreenImageViewModel
    {
        public ImageModel Image { get; set; }

        public FullScreenImageViewModel(ImageModel image) {
            Image = image;
        }
    }
}
