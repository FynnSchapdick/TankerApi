using Newtonsoft.Json;

namespace TankerApi.Models
{
    public class Station
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
        
        [JsonProperty("brand")]
        public string Brand { get; set; }
        
        [JsonProperty("street")]
        public string Street { get; set; }
        
        [JsonProperty("place")]
        public string Place { get; set; }
        
        [JsonProperty("lat")]
        public double Lat { get; set; }
        
        [JsonProperty("lng")]
        public double Lng { get; set; }
        
        [JsonProperty("dist")]
        public float Dist { get; set; }
        
        [JsonProperty("price")]
        public float? Price { get; set; }
        
        [JsonProperty("isOpen")]
        public bool IsOpen { get; set; }
        
        [JsonProperty("houseNumber")]
        public string HouseNumber { get; set; }
        
        [JsonProperty("postCode")]
        public int PostCode { get; set; }

        public override string ToString()
        {
            return $"{nameof(Id)} : {Id}\n" +
                   $"{nameof(Name)} : {Name}\n" +
                   $"{nameof(Brand)} : {Brand}\n" +
                   $"{nameof(Street)} : {Street}\n" +
                   $"{nameof(Place)} : {Place}\n" +
                   $"{nameof(Lat)} : {Lat}\n" +
                   $"{nameof(Lng)} : {Lng}\n" +
                   $"{nameof(Dist)} : {Dist}\n" +
                   $"{nameof(Price)} : {Price ?? 0.00}\n" +
                   $"{nameof(IsOpen)} : {IsOpen}\n" +
                   $"{nameof(HouseNumber)} : {HouseNumber}\n" +
                   $"{nameof(PostCode)} : {PostCode}\n";
        }
    }
}