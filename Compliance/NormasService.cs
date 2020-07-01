using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Compliance
{
    public class NormasService : INormaService
    {
        private readonly HttpClient _httpClient;

        public NormasService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<string> GetNormas()
        {
            return await _httpClient.GetStringAsync(new Uri("http://localhost:6000/api/normas"));
        }
        
        public async Task<string> GetNorma(int id)
        {
            return await _httpClient.GetStringAsync(new Uri($"http://localhost:6000/api/normas/{id}"));
        }
    }
}
