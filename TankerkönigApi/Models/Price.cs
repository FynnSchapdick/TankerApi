using Newtonsoft.Json;

namespace TankerApi.Models
{
    public class Price
    {
        [JsonProperty("status")]
        public string Status { get; set; }
        
        [JsonProperty("e5")]
        public dynamic E5 { get; set; }
        
        [JsonProperty("e10")]
        public dynamic E10 { get; set; }
        
        [JsonProperty("diesel")]
        public dynamic Diesel { get; set; }

        public override string ToString()
        {
            return $"{nameof(Status)} : {Status}\n" +
                   $"{nameof(E5)} : {E5}\n" +
                   $"{nameof(E10)} : {E10}\n" +
                   $"{nameof(Diesel)} : {Diesel}\n";
        }
    }
}