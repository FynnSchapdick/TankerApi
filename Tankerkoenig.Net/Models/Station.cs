using System;
using System.Collections.Generic;
using System.Globalization;
using Newtonsoft.Json;
using Tankerkoenig.Net.Helpers;

namespace Tankerkoenig.Net.Models
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
        public string ClosesAtJson { get; set; }

        [JsonIgnore]
        public DateTime ClosesAt => !string.IsNullOrEmpty(ClosesAtJson)
            ? DateTime.ParseExact(ClosesAtJson, Constants.DateTimeFormats, CultureInfo.InvariantCulture, DateTimeStyles.None)
            : DateTime.MinValue;
        
        [JsonProperty("opensAt")]
        public string OpensAtJson { get; set; }
        
        [JsonIgnore]
        public DateTime OpensAt => !string.IsNullOrEmpty(OpensAtJson)
            ? DateTime.ParseExact(OpensAtJson, Constants.DateTimeFormats, CultureInfo.InvariantCulture, DateTimeStyles.None) 
            : DateTime.MinValue;

        [JsonProperty("openingTimes")]
        public List<OpeningTime> OpeningTimes { get; set; }

        [JsonProperty("dist")]
        public float Dist { get; set; }
        
        [JsonProperty("fuels")]
        public List<Fuel> Fuels { get; set; }
    }
}