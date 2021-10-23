using System;
using System.Globalization;
using Newtonsoft.Json;

namespace Tankerkoenig.Net.Models
{
    public class Time
    {
        [JsonProperty("open")]
        private string OpenJson { get; set; }
        
        [JsonIgnore]
        public TimeSpan Open => !string.IsNullOrEmpty(OpenJson)
            ? DateTime.ParseExact(OpenJson, "HH:mm", CultureInfo.InvariantCulture).TimeOfDay
            : TimeSpan.Zero;
        
        [JsonProperty("close")]
        private string CloseJson { get; set; }
        
        [JsonIgnore]
        public TimeSpan Close => !string.IsNullOrEmpty(CloseJson)
            ? DateTime.ParseExact(CloseJson, "HH:mm", CultureInfo.InvariantCulture).TimeOfDay
            : TimeSpan.Zero;
    }
}