using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CursoIT.Xamarin.Interfaces
{
    public interface INetworkService
    {
        Task<bool> IsNetworkAvailable();
    }
}
