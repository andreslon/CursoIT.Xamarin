using CursoIT.Xamarin.Interfaces;
using CursoIT.Xamarin.Services;
using Newtonsoft.Json;
using System;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

[assembly: Xamarin.Forms.Dependency(typeof(FileService))]
namespace CursoIT.Xamarin.Services
{
    public class FileService : IFileService
    {
        public async Task SaveAsync<T>(string fileName, T content)
        {
            await Task.Run(() =>
            {
                var documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
                var filePath = Path.Combine(documentsPath, fileName);

                if (File.Exists(filePath))
                {
                    File.Delete(filePath);
                }
                string result = JsonConvert.SerializeObject(content);
                File.WriteAllText(filePath, result);
            });
        }
        public async Task<TResponse> LoadAsync<TResponse>(string fileName)
        {
            try
            {
                return await Task.Run(async () =>
                {
                    if (await ExistAsync(fileName))
                    {
                        var documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
                        var filePath = Path.Combine(documentsPath, fileName);

                        string result = System.IO.File.ReadAllText(filePath);
                        if (result.Equals("{}") || string.IsNullOrEmpty(result.Trim()) || result.Equals("\"\""))
                        {
                            return default(TResponse);
                        }
                        else
                        {
                            TResponse serializedResponse = JsonConvert.DeserializeObject<TResponse>(result);
                            return serializedResponse;
                        }
                    }
                    else
                        return default(TResponse);
                });
            }
            catch (Exception ex)
            {
                return default(TResponse);
            }
        }
        public async Task<bool> DeleteAsync(string fileName)
        {

            try
            {
                return await Task.Run<bool>(() =>
                {
                    var documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
                    var filePath = Path.Combine(documentsPath, fileName);
                    if (File.Exists(filePath))
                    {
                        File.Delete(filePath);
                        return true;
                    }
                    return false;
                });
            }
            catch (Exception)
            {
                return false;
            }

        }
        public async Task<bool> ExistAsync(string fileName)
        {
            return await Task.Run<bool>(() =>
            {
                var documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
                var filePath = Path.Combine(documentsPath, fileName);
                if (File.Exists(filePath))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            });
        }
         
    }
}
