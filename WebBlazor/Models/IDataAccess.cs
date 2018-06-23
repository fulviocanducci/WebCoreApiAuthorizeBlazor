using System.Threading.Tasks;
namespace WebBlazor.Models
{
    public interface IDataAccess
    {
        IDataAccess SetToken(string token);
        Task<T> GetAsync<T>(string url);
        Task<T> PostAsync<T, TValue>(string url, TValue value);
        Task<T> PutAsync<T>(string url, object value);
        Task<T> DeleteAsync<T>(string url, object value = null);
    }
}
