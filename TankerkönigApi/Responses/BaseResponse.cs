using Newtonsoft.Json;

namespace TankerApi.Responses
{
    public class BaseResponse
    {
        [JsonProperty("ok")]
        public bool Ok { get; set; }
        
        [JsonProperty("license")]
        public string License { get; set; }
        
        [JsonProperty("data")]
        public string Data { get; set; }
    }
}