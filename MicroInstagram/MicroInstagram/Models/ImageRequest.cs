using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text;

namespace MicroInstagram.Models
{
    class ImageRequest
    {
        [JsonProperty(PropertyName = "title")]
        public string Title { get; set; }
        [JsonProperty(PropertyName = "url")]
        private string Url { get; set; }

        public ImageRequest(string title)
        {
            this.Title = title;
            Url = RandomImage();
        }

        private string RandomImage()
        {
            var lista = new List<String>();
            lista.Add("https://via.placeholder.com/600/92c952");
            lista.Add("https://via.placeholder.com/600/771796");
            lista.Add("https://via.placeholder.com/600/24f355");
            lista.Add("https://via.placeholder.com/600/d32776");
            lista.Add("https://via.placeholder.com/600/f66b97");
            lista.Add("https://via.placeholder.com/600/56a8c2");
            lista.Add("https://via.placeholder.com/600/b0f7cc");
            lista.Add("https://via.placeholder.com/600/54176f");
            lista.Add("https://via.placeholder.com/600/810b14");
            lista.Add("https://via.placeholder.com/600/197d29");
            var random = new Random();
            int lndex = random.Next(lista.Count);
            return lista[lndex];
        }
    }
}
