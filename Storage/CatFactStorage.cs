using CatFacts.Models;

namespace CatFacts.Storage
{
    public class CatFactStorage
    {
        private readonly string _filePath;

        public CatFactStorage()
        {
            string documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            _filePath = Path.Combine(documentsPath, "catfacts.txt");
        }

        public void WriteToFile(CatFact? catfact)
        {
            try
            {
                if (catfact?.Fact is not null)
                {
                    File.AppendAllText(_filePath, catfact.Fact + Environment.NewLine);
                    Console.WriteLine("Cat fact saved to a file.");
                }
                else
                {
                    Console.WriteLine("Failed fetching a cat fact.");
                    return;
                }
            }
            catch (IOException ex)
            {
                Console.WriteLine($"File error: {ex.Message}");
            }
            catch (UnauthorizedAccessException ex)
            {
                Console.WriteLine($"Access denied: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Unexpected error: {ex.Message}");
            }
        }
    }
}