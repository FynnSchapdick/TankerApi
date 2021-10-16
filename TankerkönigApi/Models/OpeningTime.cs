using System.Collections.Generic;
using Newtonsoft.Json;
using TankerApi.Enums;

namespace TankerApi.Models
{
    public class OpeningTime
    {
        [JsonProperty("days")]
        public List<Day> Days { get; set; }

        [JsonProperty("times")]
        public List<Time> Times { get; set; }
    }
}