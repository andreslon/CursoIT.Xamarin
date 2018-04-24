using CursoIT.Xamarin.Insfrastructure;
using CursoIT.Xamarin.Interfaces;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

[assembly: Xamarin.Forms.Dependency(typeof(HttpClientService))]
namespace CursoIT.Xamarin.Insfrastructure
{
    class HttpClientService : IHttpClientService
    {
        async public Task<HttpResponseMessage> Get(string apiUri)
        {
            using (var client = new HttpClient())
            {
                return await client.GetAsync(new Uri(apiUri));
            }
        }
    }
}
