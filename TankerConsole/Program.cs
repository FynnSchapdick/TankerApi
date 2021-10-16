using System.Threading.Tasks;
using TankerApi;
using TankerApi.Requests;

namespace TankerConsole
{
    class Program
    {
        static async Task Main(string[] args)
        {
            string apiKey = "cffa4fb8-7a16-cd85-7946-263722530f15"; // default api-key from swagger

            TankerKoenig tanker = new TankerKoenig(apiKey);
            
            SearchRequest request = new SearchRequest("23730");

            var response = await tanker.SendAsync(request);
        }
    }
}