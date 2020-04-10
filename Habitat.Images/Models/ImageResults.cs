using System.Collections.Generic;
using Newtonsoft.Json;

namespace Habitat.Images.Models
{
    public class ImageResults
    {
        [JsonProperty("hits")]
        public List<ImageRecord> Hits { get; set; }
        
        [JsonProperty("total")]
        public int Total { get; set; }
    }

    public class ImageRecord
    {
        
        [JsonProperty("largeImageURL")]
        public string LargeImageUrl { get; set; }
    }
}