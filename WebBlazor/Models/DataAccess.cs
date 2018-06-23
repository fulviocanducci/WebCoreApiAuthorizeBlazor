using System.Net.Http;
using System.Threading.Tasks;
using System.Net.Http.Headers;
using Microsoft.AspNetCore.Blazor;

namespace WebBlazor.Models
{
    public class DataAccess : IDataAccess
    {
        private readonly HttpClient Http;

        public DataAccess(HttpClient http)
        {
            Http = http;
            //Http.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("","");
            Http.BaseAddress = new System.Uri("http://localhost:8989");
            http.DefaultRequestHeaders.Add("Authorization", "Bearer ");
            
        }

        public IDataAccess SetToken(string token)
        {            
            Http.DefaultRequestHeaders.Remove("Authorization");
            Http.DefaultRequestHeaders.Add("Authorization", $"Bearer {token}");
            return this;
        }

        public async Task<T> DeleteAsync<T>(string url, object value = null)
        {
            return await Http.SendJsonAsync<T>(HttpMethod.Delete, url, value);
        }

        public async Task<T> GetAsync<T>(string url)
        {
            return await Http.GetJsonAsync<T>(url);
        }

        public async Task<T> PostAsync<T, TValue>(string url, TValue value)
        {
            return await Http.PostJsonAsync<T>(url, value);
        }

        public async Task<T> PutAsync<T>(string url, object value)
        {
            return await Http.PutJsonAsync<T>(url, value);
        }
    }
}
