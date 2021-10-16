using System.Collections.Generic;
using System.Net.Http;
using TankerApi.Interfaces;
using TankerApi.Responses;

namespace TankerApi.Requests
{
    public class SearchRequest : IRequest<SearchResponse>
    {
        private readonly List<string> _ids;
        private readonly float _latitude;
        private readonly float _longitude;
        private readonly int _radius;
        private List<KeyValuePair<string, object>> _parameters = new List<KeyValuePair<string, object>>();

        public string ApiKey
        {
            set => _parameters.Add(new KeyValuePair<string, object>("apikey", value));
        }
        public string EndpointUrl { get; }
        public HttpMethod Method { get; } = HttpMethod.Get;

        public List<KeyValuePair<string, object>> Parameters => _parameters;

        public SearchRequest(float latitude, float longitude, int radius = 0)
        {
            _latitude = latitude;
            _longitude = longitude;
            _radius = radius > 25 ? 25 : radius;
            EndpointUrl = "stations/search";
        }

        public SearchRequest(List<string> ids, float latitude, float longitude)
        {
            _ids = ids;
            _latitude = latitude;
            _longitude = longitude;
            EndpointUrl = "stations/ids";
        }

        public SearchRequest(string postalCode)
        {
            EndpointUrl = "stations/postalcode";
            _parameters.Add(new KeyValuePair<string, object>("postalcode", postalCode));
        }
    }
}