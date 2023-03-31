using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace MicroInstagram.Models
{
    public class ImageModel
    {
        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }
        [JsonProperty(PropertyName = "title")]
        public string Title { get; set; }
        [JsonProperty(PropertyName = "url")]
        public string Url { get; set; }
    }
}
