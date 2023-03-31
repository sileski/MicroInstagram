using MicroInstagram.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MicroInstagram.Services
{
    class ImagesApiService : IImagesApiService
    {
        private const string ApiUrl = "https://jsonplaceholder.typicode.com";
        private HttpClient httpClient;

        public ImagesApiService()
        {
            this.httpClient = new HttpClient();
        }

        public async Task<Result<List<ImageModel>>> GetPhotos(int start, int limit)
        {
            try
            {
                string url = $"{ApiUrl}/photos?_start={start}&_limit={limit}";
                HttpResponseMessage response = await httpClient.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    string resultJson = await response.Content.ReadAsStringAsync();
                    List<ImageModel> result = JsonConvert.DeserializeObject<List<ImageModel>>(resultJson);
                    return new Result<List<ImageModel>>.Success(result);
                }
                return new Result<List<ImageModel>>.Failure("Unable to get images");
            } catch(Exception exception)
            {
                return new Result<List<ImageModel>>.Failure(exception.Message);
            }
        }

        public async Task<Result<object>> DeleteImage(int imageId)
        {
            try
            {
                string url = $"{ApiUrl}/photos/{imageId}";
                Console.WriteLine(url);
                httpClient = new HttpClient();
                HttpResponseMessage response = await httpClient.DeleteAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    return new Result<object>.Success(null);
                }
                return new Result<object>.Failure("Unable delete image");
            } catch(Exception exception)
            {
                return new Result<object>.Failure(exception.Message);
            }
        }

        public async Task<Result<ImageModel>> AddNewImage(ImageRequest imageRequest, Stream imageStream)
        {
            try
            {
                string url = $"{ApiUrl}/photos";
                StringContent bodyContent = new StringContent(JsonConvert.SerializeObject(imageRequest), Encoding.UTF8, "application/json");
                HttpResponseMessage response = await httpClient.PostAsync(url, bodyContent);
                if (response.IsSuccessStatusCode)
                {
                    string resultJson = await response.Content.ReadAsStringAsync();
                    ImageModel result = JsonConvert.DeserializeObject<ImageModel>(resultJson);
                    Console.WriteLine(result.Title);
                    return new Result<ImageModel>.Success(result);
                }
                return new Result<ImageModel>.Failure("Unable to add new image");
            }
            catch (Exception exception)
            {
                return new Result<ImageModel>.Failure(exception.Message);
            }
        }

        public async Task<Result<ImageModel>> UpdateImageDetails(ImageModel image)
        {
            try
            {
                string url = $"{ApiUrl}/photos/{image.Id}";
                StringContent bodyContent = new StringContent(JsonConvert.SerializeObject(image), Encoding.UTF8, "application/json");
                HttpResponseMessage response = await httpClient.PutAsync(url, bodyContent);
                if (response.IsSuccessStatusCode)
                {
                    string resultJson = await response.Content.ReadAsStringAsync();
                    ImageModel result = JsonConvert.DeserializeObject<ImageModel>(resultJson);
                    return new Result<ImageModel>.Success(result);
                }
                return new Result<ImageModel>.Failure("Unable to update image details");
            }
            catch (Exception exception)
            {
                return new Result<ImageModel>.Failure(exception.Message);
            }
        }
    }
}
