using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using System.Xml.Linq;
using CardSearcher.Entities;

namespace CardSearcher.Entities.Services
{
    public class CardServices
    {
        private static readonly HttpClient httpClient = new HttpClient();

        public async Task<MagicCardResponse> GetCardByNameAsync(string name)
        {
            string url = $"https://api.magicthegathering.io/v1/cards?name={Uri.EscapeDataString(name)}";
            HttpResponseMessage response = await httpClient.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                string json = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<MagicCardResponse>(json, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            }

            return null;
        }

        public async Task<MagicCardResponseSingle> GetCardByIdAsync(string id)
        {
            string url = $"https://api.magicthegathering.io/v1/cards/{id}";
            HttpResponseMessage response = await httpClient.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                string json = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<MagicCardResponseSingle>(json, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            }

            return null;
        }
    }
}
