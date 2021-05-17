using System;
using System.Collections.Generic;
using System.Linq;

namespace TankerApi.Extensions
{
    public static class ObjectExtensions
    {
        public static List<KeyValuePair<string, object>> GetPropertiesKeyValuePairs(this object me) 
        {
            List<KeyValuePair<string, object>> result = new List<KeyValuePair<string, object>>();
            foreach (var property in me.GetType()
                .GetProperties()
                .Where(x => 
                    x.Name != "EndpointUrl" 
                    && x.Name != "Method")) 
            {
                result.Add(new KeyValuePair<string, object>(property.Name.ToLower(), property.GetValue(me)));
            }
            return result;
        }
        
        public static List<KeyValuePair<string, object>> GetPropertyKeyValuePair(this object me) 
        {
            List<KeyValuePair<string, object>> result = new List<KeyValuePair<string, object>>();
            string concated = String.Empty;
            foreach (var property in me.GetType()
                .GetProperties()
                .Where(x => 
                    x.Name != "EndpointUrl" 
                    && x.Name != "Method"))
            {
                if (property.GetValue(me) is List<string> list)
                {
                    string delimiter = ",";
                    concated = list.Aggregate((i, j) => i + delimiter + j);
                }
                
                result.Add(new KeyValuePair<string, object>(property.Name.ToLower(), concated));
            }
            return result;
        }
        
    }
}