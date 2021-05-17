using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using TankerApi.Common;
using TankerApi.Responses;

namespace TankerApi.Requests
{
    public class PriceRequest : IRequest<PriceResponse>
    {
        private readonly List<string> _stationIds;
        public List<string> Ids => _stationIds;
        public string EndpointUrl { get; }
        public HttpMethod Method { get; }
        public PriceRequest(List<string> stationIds)
        {
            if (!stationIds.Any())
            {
                throw new Exception("Request need stationIds");
            }

            if (stationIds.Count > 10)
            {
                throw new Exception("10 is the limit for stationIds");
            }
            
            _stationIds = stationIds;
            Method = HttpMethod.Get;
            EndpointUrl = "prices.php";
        }
    }
}