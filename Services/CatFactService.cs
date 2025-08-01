using System.Text.Json;
using CatFacts.Models;

namespace CatFacts.Services
{
    public class CatFactService
    {
        private readonly HttpClient _client;
        public CatFactService(HttpClient client)
        {
            _client = client;
        }

        public async Task<CatFact?> GetCatFactAsync()
        {
            try
            {
                string response = await _client.GetStringAsync("https://catfact.ninja/fact");
                return JsonSerializer.Deserialize<CatFact>(response);
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"HTTP error: {ex.Message}");
                return null;
            }
            catch (JsonException ex)
            {
                Console.WriteLine($"Parsing error: {ex.Message}");
                return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Unexpected error: {ex.Message}");
                return null;
            }
        }
    }
}