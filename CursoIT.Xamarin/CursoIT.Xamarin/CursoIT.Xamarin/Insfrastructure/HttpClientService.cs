using CursoIT.Xamarin.Insfrastructure;
using CursoIT.Xamarin.Interfaces;
using Newtonsoft.Json;
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
        async public Task<HttpResponseMessage> Put<TRequest>(string apiUri, TRequest request)
        {
            using (var client = new HttpClient())
            {
                string bodyRequest = JsonConvert.SerializeObject(request);
                return await client.PutAsync(apiUri, 
                    new StringContent(bodyRequest, Encoding.UTF8, "application/json"));
            }
        }
        async public Task<HttpResponseMessage> Post<TRequest>(string apiUri, TRequest request)
        {
            using (var client = new HttpClient())
            {
                string bodyRequest = JsonConvert.SerializeObject(request);
                return await client.PostAsync(apiUri, 
                    new StringContent(bodyRequest, Encoding.UTF8, "application/json"));
            }
        }
    }
}
