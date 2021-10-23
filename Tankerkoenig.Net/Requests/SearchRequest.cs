using System.Collections.Generic;
using System.Net.Http;
using Tankerkoenig.Net.Interfaces;
using Tankerkoenig.Net.Responses;

namespace Tankerkoenig.Net.Requests
{
    public class SearchRequest : IRequest<SearchResponse>
    {
        private List<KeyValuePair<string, object>> _parameters = new List<KeyValuePair<string, object>>();
        
        public string ApiKey
        {
            set => _parameters.Add(new KeyValuePair<string, object>("apikey", value));
        }
        public string EndpointUrl { get; }
        public HttpMethod Method { get; } = HttpMethod.Get;

        public List<KeyValuePair<string, object>> Parameters => _parameters;

        public SearchRequest(double latitude, double longitude, int radius = 0)
        {
            EndpointUrl = "stations/search";
            _parameters.Add(new KeyValuePair<string, object>("lat", latitude));
            _parameters.Add(new KeyValuePair<string, object>("lng", longitude));
            _parameters.Add(new KeyValuePair<string, object>("rad", radius > 25 ? 25 : radius));
        }

        public SearchRequest(List<string> ids, double? latitude = null, double? longitude = null)
        {
            EndpointUrl = "stations/ids";
            _parameters.Add(new KeyValuePair<string, object>("ids", ids));
            
            if (latitude.HasValue
                && longitude.HasValue)
            {
                _parameters.Add(new KeyValuePair<string, object>("lat", latitude.Value));
                _parameters.Add(new KeyValuePair<string, object>("lng", longitude.Value));
            }
        }

        public SearchRequest(string postalCode)
        {
            EndpointUrl = "stations/postalcode";
            _parameters.Add(new KeyValuePair<string, object>("postalcode", postalCode));
        }
    }
}