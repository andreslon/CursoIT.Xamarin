using CursoIT.Xamarin.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Plugin.Connectivity;
using CursoIT.Xamarin.Services;

[assembly: Xamarin.Forms.Dependency(typeof(NetworkService))]
namespace CursoIT.Xamarin.Services
{
    public class NetworkService : INetworkService
    {
        async public Task<bool> IsNetworkAvailable()
        {
            var connectivity = CrossConnectivity.Current;
            if (!connectivity.IsConnected)
                return false;

            var reachable = await connectivity.IsRemoteReachable("http://cursoitapi.azurewebsites.net");
            return reachable;
        }
    }
}
