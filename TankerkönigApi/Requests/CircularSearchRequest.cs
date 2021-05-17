using System;
using System.Collections.Generic;
using System.Net.Http;
using TankerApi.Common;
using TankerApi.Enums;
using TankerApi.Extensions;
using TankerApi.Responses;

namespace TankerApi.Requests
{
    public class CircularSearchRequest : IRequest<CircularSearchResponse>
    {
        private readonly float _latitude;
        
        private readonly float _longitude;
        
        private readonly float _radius;

        private readonly FuelEnum _fuelType;

        private readonly SortEnum _sort;

        public double Lat => _latitude;
        public double Lng => _longitude;
        public double Rad => _radius;
        public string Type => _fuelType.ToString();
        public string Sort => _sort.ToString();
        public string EndpointUrl { get; set; }
        public HttpMethod Method { get; }

        public CircularSearchRequest(float latitude, float longitude, float radius, FuelEnum fuelType, SortEnum sortType)
        {
            _latitude = latitude;
            _longitude = longitude;
            _radius = radius;
            _fuelType = fuelType;
            _sort = sortType;
            EndpointUrl = "list.php";
            Method = HttpMethod.Get;
        }
    }
}