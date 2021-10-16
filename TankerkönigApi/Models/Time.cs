using Newtonsoft.Json;

namespace TankerApi.Models
{
    public class Time
    {
        [JsonProperty("open")]
        private string Open { get; set; }
        
        [JsonProperty("close")]
        private string Close { get; set; }
    }
}