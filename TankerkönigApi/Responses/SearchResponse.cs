﻿using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using TankerApi.Models;

namespace TankerApi.Responses
{
    public class SearchResponse
    {
        [JsonProperty("apiVersion")]
        public string ApiVersion { get; set; }
        
        [JsonProperty("timestamp")]
        public DateTime Timestamp { get; set; }
        
        [JsonProperty("stations")]
        public IList<Station> Stations { get; set; }
        
        [JsonProperty("statusCode")]
        public int Code { get; set; }
        
        [JsonProperty("message")]
        public string Message { get; set; }
    }
}