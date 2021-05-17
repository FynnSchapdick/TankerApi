using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;
using TankerApi.Common;
using TankerApi.Extensions;
using TankerApi.Requests;

namespace TankerApi
{
    public class TankerKoenig
    {
        private readonly string _apiKey;
        private readonly HttpClient _client;
        private readonly Uri _baseUri;

        public TankerKoenig(string apiKey)
        {
            _apiKey = apiKey;
            _client = new HttpClient();
            _baseUri = new Uri("https://creativecommons.tankerkoenig.de/json/");
        }

        public async Task<TResponse> SendAsync<TResponse>(IRequest<TResponse> request, CancellationToken cancellationToken = default)
        {
            using HttpRequestMessage message = new HttpRequestMessage {Method = request.Method};
            List<KeyValuePair<string, object>> keyValuePairs = null;
            switch (request)
            {
                case CircularSearchRequest circularSearchRequest:
                    keyValuePairs = circularSearchRequest.GetPropertiesKeyValuePairs();
                    break;
                
                case PriceRequest priceRequest:
                    keyValuePairs = priceRequest.GetPropertyKeyValuePair();
                    break;
            }

            if (keyValuePairs is null 
                || !keyValuePairs.Any())
            {
                throw new Exception("KeyValuePairs cannot be empty");
            }

            message.RequestUri = _baseUri.AddEndpointWithParameters(request.EndpointUrl, keyValuePairs).AddApiKey("apikey", _apiKey);

            HttpResponseMessage result = await _client.SendAsync(message, cancellationToken);
            
            var content = await result.Content.ReadAsStringAsync(cancellationToken);

            return JsonConvert.DeserializeObject<TResponse>(content, new JsonSerializerSettings{NullValueHandling = NullValueHandling.Ignore});
        }
    }
}