using System.Threading.Tasks;
namespace WebBlazor.Models
{
    public interface IDataAccess
    {
        Task<T> GetAsync<T>(string url);
        Task<T> PostAsync<T>(string url, T value);
        Task<T> PutAsync<T>(string url, object value);
        Task<T> DeleteAsync<T>(string url, object value = null);
    }
}
