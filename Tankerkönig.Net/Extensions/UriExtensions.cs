using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO.IsolatedStorage;
using System.Linq;
using System.Text;
using System.Web;

namespace TankerApi.Extensions
{
    public static class UriExtensions
    {
        public static Uri AddEndpointWithParameters(this Uri baseUrl, string endpointUrl ,List<KeyValuePair<string, object>> parameters)
        {
            Uri uri = new Uri(baseUrl, endpointUrl);
            var uriBuilder = new UriBuilder(uri);
            var query = HttpUtility.ParseQueryString(uriBuilder.Query);

            foreach (var parameter in parameters)
            {
                query[parameter.Key] = GetUtf8String(parameter.Value);
            }

            uriBuilder.Query = query.ToString() ?? string.Empty;

            return uriBuilder.Uri;
        }
        
        private static string GetUtf8String(object value)
        {
            string result = string.Empty;

            switch (value)
            {
                case double doubleValue:
                    result = doubleValue.ToString(CultureInfo.InvariantCulture);
                    break;
                
                case int intValue:
                    result = intValue.ToString(CultureInfo.InvariantCulture);
                    break;
                
                case List<string> idsValue:
                    result = string.Join(",", idsValue).ToString(CultureInfo.InvariantCulture);
                    break;
                
                case string stringValue:
                    result = stringValue;
                    break;
            }
            
            byte[] bytes = Encoding.Default.GetBytes(result);
            return Encoding.UTF8.GetString(bytes);
        }
    }
}