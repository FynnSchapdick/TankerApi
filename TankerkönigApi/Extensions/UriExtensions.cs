using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Web;

namespace TankerApi.Extensions
{
    public static class UriExtensions
    {
        public static Uri AddApiKey(this Uri url, string paramName, string paramValue)
        {
            var uriBuilder = new UriBuilder(url);
            var query = HttpUtility.ParseQueryString(uriBuilder.Query);
            query[paramName] = GetUtf8String(paramValue);
            uriBuilder.Query = query.ToString();
            return uriBuilder.Uri;
        }
        
        public static Uri AddEndpointWithParameters(this Uri baseUrl, string endpointUrl ,List<KeyValuePair<string, object>> parameters)
        {
            Uri uri = new Uri(baseUrl, endpointUrl);
            var uriBuilder = new UriBuilder(uri);
            var query = HttpUtility.ParseQueryString(uriBuilder.Query);

            foreach (var parameter in parameters)
            {
                query[parameter.Key] = GetUtf8String(parameter.Value);
            }

            uriBuilder.Query = query.ToString();

            return uriBuilder.Uri;
        }
        
        private static string GetUtf8String(object value)
        {
            string result = "";

            if (value is double floatValue)
            {
                result = floatValue.ToString(CultureInfo.InvariantCulture);
            }
            else if (value is string stringValue)
            {
                result = stringValue;
            }
            
            byte[] bytes = Encoding.Default.GetBytes(result);
            return Encoding.UTF8.GetString(bytes);
        }
    }
}