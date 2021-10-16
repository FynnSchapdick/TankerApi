using System.Collections.Generic;
using System.Net.Http;

namespace TankerApi.Interfaces
{
    public interface IRequest<out TResponse>
    {
        public string ApiKey { set; }
        public string EndpointUrl { get; }
        public HttpMethod Method { get; }
        public List<KeyValuePair<string, object>> Parameters { get; }
    }
}