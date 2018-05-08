using CursoIT.Xamarin.Interfaces;
using CursoIT.Xamarin.Models;
using CursoIT.Xamarin.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Newtonsoft.Json;
using CursoIT.Xamarin.Resources;

[assembly: Xamarin.Forms.Dependency(typeof(CinemaRepository))]
namespace CursoIT.Xamarin.Repositories
{
    public class CinemaRepository : ICinemaRepository
    {
        public string ApiUri { get; set; } = ApiResources.ApiUri;

        public IHttpClientService HttpClientService { get; set; }
        public CinemaRepository()
        {
            HttpClientService = DependencyService.Get<IHttpClientService>();
        }
        async public Task<List<Cinema>> GetCinemas()
        {
            var result = await HttpClientService
                .Get($"{ApiUri}Cinemas");
            if (result.IsSuccessStatusCode)
            {
                string content = await result.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<Cinema>>(content);
            }
            return null;
        }
    }
}
