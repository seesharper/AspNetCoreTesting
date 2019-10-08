using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace AspNetCoreTesting
{
    public static class HttpClientExtensions
    {
        public static async Task<T> ContentAs<T>(this HttpResponseMessage response)
        {
            var data = await response.Content.ReadAsStreamAsync();
            return data.Length == 0 ?
                            default(T) :
                            await JsonSerializer.DeserializeAsync<T>(data);
        }
    }


}