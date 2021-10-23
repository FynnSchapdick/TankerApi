using System.ComponentModel;
using Newtonsoft.Json;
using Tankerkoenig.Net.Helpers;

namespace Tankerkoenig.Net.Enums
{
    [JsonConverter(typeof(DayConverter))]
    public enum ApiDay
    {
        [Description("Montag")]
        mon,
        [Description("Dienstag")]
        tue,
        [Description("Mittwoch")]
        wed,
        [Description("Donnerstag")]
        thu,
        [Description("Freitag")]
        fri,
        [Description("Samstag")]
        sat,
        [Description("Sonntag")]
        sun,
        [Description("Feiertag")]
        hol
    }
}