using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using TankerApi.Extensions;
using TankerApi.Interfaces;

namespace TankerApi
{
    public class TankerKoenig
    {
        private const string _baseUrl = "https://creativecommons.tankerkoenig.de/api/v4/";
        private readonly string _apiKey;
        private readonly HttpClient _client;
        private readonly Uri _baseUri;

        public TankerKoenig(string apiKey)
        {
            _apiKey = apiKey;
            _client = new HttpClient();
            _baseUri = new Uri(_baseUrl);
        }

        public async Task<TResponse> SendAsync<TResponse>(IRequest<TResponse> request, CancellationToken cancellationToken = default)
        {
            request.ApiKey = _apiKey;
            
            using HttpRequestMessage message = new HttpRequestMessage {Method = request.Method};
            
            message.RequestUri = _baseUri.AddEndpointWithParameters(request.EndpointUrl, request.Parameters);

            HttpResponseMessage result = await _client.SendAsync(message, cancellationToken);
            
            string content = await result.Content.ReadAsStringAsync(cancellationToken);

            return JsonConvert.DeserializeObject<TResponse>(content,
                new JsonSerializerSettings
                {
                    NullValueHandling = NullValueHandling.Ignore,
                    Converters = new List<JsonConverter> {new IsoDateTimeConverter()}
                });
        }
    }
}