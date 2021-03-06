using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Tankerkoenig.Net;
using Tankerkoenig.Net.Requests;
using Tankerkoenig.Net.Responses;

namespace TankerConsole
{
    class Program
    {
        static async Task Main(string[] args)
        {
            string apiKey = "cffa4fb8-7a16-cd85-7946-263722530f15"; // default api-key from swagger

            TankerKoenig tanker = new TankerKoenig(apiKey, new HttpClient());

            SearchRequest lngLatRadRequest = new SearchRequest(54.10707,10.8145, 25);
            SearchResponse lngLatRadResponse = await tanker.GetStationsAsync(lngLatRadRequest);
            
            SearchRequest postalCodeRequest = new SearchRequest("23730");
            SearchResponse postalCodeResponse = await tanker.GetStationsAsync(postalCodeRequest);

            SearchRequest idsWithoutLatLngRequest = new SearchRequest(new List<string> {"92f703e8-0b3c-46da-9948-25cb1a6a1514", "83d5ac80-4f23-4106-b054-7c7704bfcb95"});
            SearchResponse idsWithoutLatLngResponse = await tanker.GetStationsAsync(idsWithoutLatLngRequest);
            
            SearchRequest idsWithLatLngRequest = new SearchRequest(new List<string> {"92f703e8-0b3c-46da-9948-25cb1a6a1514", "83d5ac80-4f23-4106-b054-7c7704bfcb95"}, 54.10707, 10.8145);
            SearchResponse idsWithLatLngResponse = await tanker.GetStationsAsync(idsWithLatLngRequest);
        }
    }
}