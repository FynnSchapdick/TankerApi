using System.Collections.Generic;
using Newtonsoft.Json;
using TankerApi.Models;

namespace TankerApi.Responses
{
    public class CircularSearchResponse : BaseResponse
    {
        [JsonProperty("status")]
        public string Status { get; set; }
        
        [JsonProperty("stations")]
        public IList<Station> Stations { get; set; }
    }
}