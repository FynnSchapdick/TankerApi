using System;
using Newtonsoft.Json;

namespace TankerApi.Models
{
    public class LastChange
    {
        [JsonProperty("timestamp")]
        public DateTime Timestamp { get; set; }
        
        [JsonProperty("amount")]
        public float Amount { get; set; }
    }
}