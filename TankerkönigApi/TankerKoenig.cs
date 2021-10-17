using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using TankerApi.Extensions;
using TankerApi.Interfaces;
using TankerApi.Responses;

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

        public async Task<dynamic> SendAsync<TResponse>(IRequest<TResponse> request, CancellationToken cancellationToken = default)
        {
            request.ApiKey = _apiKey;
            
            using HttpRequestMessage message = new HttpRequestMessage {Method = request.Method};
            
            message.RequestUri = _baseUri.AddEndpointWithParameters(request.EndpointUrl, request.Parameters);

            HttpResponseMessage result = await _client.SendAsync(message, cancellationToken);
            
            string content = await result.Content.ReadAsStringAsync(cancellationToken);

            return result.StatusCode == HttpStatusCode.OK
                ? JsonConvert.DeserializeObject<TResponse>(content,
                new JsonSerializerSettings {NullValueHandling = NullValueHandling.Ignore, Converters = new List<JsonConverter> { new IsoDateTimeConverter()}})
                : JsonConvert.DeserializeObject<FailureResponse>(content,
                    new JsonSerializerSettings {NullValueHandling = NullValueHandling.Ignore, Converters = new List<JsonConverter> { new IsoDateTimeConverter()}});
        }
    }
}