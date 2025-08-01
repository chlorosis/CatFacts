using CatFacts.Services;
using CatFacts.Storage;

namespace CatFacts
{
    internal class Program
    {
        static async Task Main()
        {
            using HttpClient client = new HttpClient();
            var service = new CatFactService(client);
            var storage = new CatFactStorage();
            var catfact = await service.GetCatFactAsync();
            storage.WriteToFile(catfact);
        }
        
    }
}