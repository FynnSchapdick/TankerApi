using Newtonsoft.Json;

namespace TankerApi.Models
{
    public class Coordinates
    {
        [JsonProperty("lat")]
        public double Latitude { get; set; }
        
        [JsonProperty("lng")]
        public double Longitude { get; set; }
    }
}