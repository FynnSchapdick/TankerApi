using System.Collections.Generic;
using System.Net.Http;

namespace Tankerkoenig.Net.Interfaces
{
    public interface IRequest<out TResponse>
    {
        string ApiKey { set; }
        string EndpointUrl { get; }
        HttpMethod Method { get; }
        List<KeyValuePair<string, object>> Parameters { get; }
    }
}