using System.Collections.Generic;
using Newtonsoft.Json;
using TankerApi.Models;

namespace TankerApi.Responses
{
    public class PriceResponse : BaseResponse
    {
        [JsonProperty("prices")]
        public Dictionary<string ,Price> Prices { get; set; }
    }
}