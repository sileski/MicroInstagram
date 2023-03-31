using System.IO;
using System.Threading.Tasks;

namespace MicroInstagram.Services
{
    public interface IImagePickerService
    {
        Task<Stream> GetImageStreamAsync();
    }
}
