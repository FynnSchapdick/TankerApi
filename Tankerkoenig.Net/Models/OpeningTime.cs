using System.Collections.Generic;
using Newtonsoft.Json;
using Tankerkoenig.Net.Enums;

namespace Tankerkoenig.Net.Models
{
    public class OpeningTime
    {
        [JsonProperty("days")]
        public List<ApiDay> DaysJson { get; set; }

        [JsonProperty("times")]
        public List<Time> Times { get; set; }
    }
}