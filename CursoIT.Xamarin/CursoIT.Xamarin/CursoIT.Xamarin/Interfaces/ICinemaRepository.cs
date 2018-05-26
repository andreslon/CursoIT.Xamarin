using CursoIT.Xamarin.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CursoIT.Xamarin.Interfaces
{
    public interface ICinemaRepository
    {
        Task<List<Cinema>> GetCinemas();
        Task<bool> PutCinema(Cinema entity);
    }
}
