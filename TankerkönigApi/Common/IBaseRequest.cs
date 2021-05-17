using System;
using System.Net.Http;

namespace TankerApi.Common
{
    public interface IBaseRequest
    {
        public string EndpointUrl { get; }
        public HttpMethod Method { get; }
    }
}