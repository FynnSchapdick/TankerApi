using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Tankerkoenig.Net.Extensions;
using Tankerkoenig.Net.Interfaces;

namespace Tankerkoenig.Net
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

        public async Task<TResponse> GetStationsAsync<TResponse>(IRequest<TResponse> request)
        {
            request.ApiKey = _apiKey;

            using (HttpRequestMessage message = new HttpRequestMessage {Method = request.Method})
            {
                message.RequestUri = _baseUri.AddEndpointWithParameters(request.EndpointUrl, request.Parameters);

                HttpResponseMessage result = await _client.SendAsync(message);
            
                string content = await result.Content.ReadAsStringAsync();

                return JsonConvert.DeserializeObject<TResponse>(content,
                    new JsonSerializerSettings
                    {
                        NullValueHandling = NullValueHandling.Ignore,
                        Converters = new List<JsonConverter> { new IsoDateTimeConverter() }
                    });
            }
        }
    }
}