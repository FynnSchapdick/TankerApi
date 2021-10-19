using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace TankerApi.Models
{
    public class Station
    {
        [JsonProperty("country")]
        public string Country { get; set; }
        
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
        
        [JsonProperty("brand")]
        public string Brand { get; set; }
        
        [JsonProperty("street")]
        public string Street { get; set; }
        
        [JsonProperty("postalCode")]
        public int PostalCode { get; set; }
        
        [JsonProperty("place")]
        public string Place { get; set; }
        
        [JsonProperty("coords")]
        public Coordinates Coordinates { get; set; }
        
        [JsonProperty("isOpen")]
        public bool IsOpen { get; set; }

        [JsonProperty("closesAt")]
        public DateTime ClosesAt { get; set; }
        
        [JsonProperty("opensAt")]
        public DateTime OpensAt { get; set; }

        [JsonProperty("openingTimes")]
        public List<OpeningTime> OpeningTimes { get; set; }

        [JsonProperty("dist")]
        public float Dist { get; set; }
        
        [JsonProperty("fuels")]
        public List<Fuel> Fuels { get; set; }
    }
}