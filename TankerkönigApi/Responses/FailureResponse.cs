using Newtonsoft.Json;

namespace TankerApi.Responses
{
    public class FailureResponse
    {
        [JsonProperty("statusCode")]
        public int Code { get; set; }
        
        [JsonProperty("message")]
        public string Message { get; set; }
    }
}