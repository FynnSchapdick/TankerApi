using Newtonsoft.Json;

namespace TankerApi.Models
{
    public class Time
    {
        [JsonProperty("open")]
        private string Open { get; set; }
        
        [JsonProperty("close")]
        private string Close { get; set; }
            
        // [JsonIgnore]
        // public DateTime OpenTime
        // {
        //     get
        //     {
        //         DateTime dateTime;
        //         return DateTime.TryParseExact(OpenJson, "HH:mm:ss", CultureInfo.InvariantCulture, DateTimeStyles.None,
        //             out dateTime)
        //             ? dateTime
        //             : default;
        //     }
        //     set => OpenJson = value.ToString("HH:mm:ss");
        // }
        //
        // [JsonIgnore]
        // public DateTime CloseTime
        // {
        //     get
        //     {
        //         DateTime dateTime;
        //         return DateTime.TryParseExact(CloseJson, "HH:mm:ss", CultureInfo.InvariantCulture, DateTimeStyles.None,
        //             out dateTime)
        //             ? dateTime
        //             : default;
        //     }
        //     set => CloseJson = value.ToString("HH:mm:ss");
        // }
    }
}