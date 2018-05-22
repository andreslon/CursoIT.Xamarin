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
        public INetworkService NetworkService { get; set; }
        public IFileService FileService { get; set; }
        public CinemaRepository()
        {
            HttpClientService = DependencyService.Get<IHttpClientService>();
            NetworkService = DependencyService.Get<INetworkService>();
            FileService = DependencyService.Get<IFileService>();
        }
        async public Task<List<Cinema>> GetCinemas()
        {
            try
            {
                if (await NetworkService.IsNetworkAvailable())
                {
                    var result = await HttpClientService
                    .Get($"{ApiUri}Cinemas");
                    if (result.IsSuccessStatusCode)
                    {
                        string content = await result.Content.ReadAsStringAsync();
                        await FileService.SaveAsync("Cinemas", content);
                        return JsonConvert.DeserializeObject<List<Cinema>>(content);
                    }
                }
                else
                {
                    if (await FileService.ExistAsync("Cinemas"))
                    {
                        var fileContent = await FileService.LoadAsync<string>("Cinemas");
                        return JsonConvert.DeserializeObject<List<Cinema>>(fileContent);
                    }
                }
            }
            catch (Exception ex)
            {
 
            } 
            return null;
        }
    }
}
