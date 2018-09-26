using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CursoIT.Xamarin.Interfaces
{
    public interface IFileService
    {
        Task SaveAsync<T>(string fileName, T content);
        Task<TResponse> LoadAsync<TResponse>(string fileName);
        Task<bool> ExistAsync(string fileName);
        Task<bool> DeleteAsync(string fileName);
    }
}
