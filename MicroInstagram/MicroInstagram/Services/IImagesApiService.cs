using MicroInstagram.Models;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace MicroInstagram.Services
{
    interface IImagesApiService
    {
        Task<Result<List<ImageModel>>> GetPhotos(int start, int limit);
        Task<Result<object>> DeleteImage(int imageId);
        Task<Result<ImageModel>> AddNewImage(ImageRequest imageRequest, Stream imageStream);
        Task<Result<ImageModel>> UpdateImageDetails(ImageModel image);
    }
}
