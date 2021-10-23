using System;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using Newtonsoft.Json;
using Tankerkoenig.Net.Enums;

namespace Tankerkoenig.Net.Helpers
{
    public class DayConverter : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            string dayValue = ((DescriptionAttribute)typeof(ApiDay).GetMembers()
                .FirstOrDefault(x =>
                    x.GetCustomAttributes(typeof(DescriptionAttribute)).Any()
                    && x.Name == (string) reader.Value)
                ?.GetCustomAttributes(typeof(DescriptionAttribute)).FirstOrDefault())?.Description;

            if (!string.IsNullOrEmpty(dayValue))
            {
                return Enum.Parse(typeof(Day), dayValue);
            }
            
            return Enum.Parse(typeof(ApiDay), (string)reader.Value ?? string.Empty);
        }

        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(Day);
        }
    }
}