using Newtonsoft.Json;

namespace Tankerkoenig.Net.Models
{
    public class FuelStat
    {
        [JsonProperty("count")]
        public int Count { get; set; }
        
        [JsonProperty("mean")]
        public float Mean { get; set; }

        [JsonProperty("median")]
        public float Median { get; set; }
    }
}