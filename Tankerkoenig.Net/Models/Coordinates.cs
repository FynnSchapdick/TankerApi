using Newtonsoft.Json;

namespace Tankerkoenig.Net.Models
{
    public class Coordinates
    {
        [JsonProperty("lat")]
        public double Latitude { get; set; }
        
        [JsonProperty("lng")]
        public double Longitude { get; set; }
    }
}