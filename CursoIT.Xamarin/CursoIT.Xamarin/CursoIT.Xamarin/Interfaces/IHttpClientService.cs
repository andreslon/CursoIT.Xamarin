using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CursoIT.Xamarin.Interfaces
{
    public interface IHttpClientService
    {
        Task<HttpResponseMessage> Get(string apiUri);
    }
}
