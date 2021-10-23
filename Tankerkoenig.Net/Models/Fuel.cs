using Newtonsoft.Json;

namespace Tankerkoenig.Net.Models
{
    public class Fuel
    {
        [JsonProperty("category")]
        public Enums.Fuel Category { get; set; }
        
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("price")]
        public float Price { get; set; }

        [JsonProperty("lastChange")]
        public LastChange LastChange { get; set; }
    }
}