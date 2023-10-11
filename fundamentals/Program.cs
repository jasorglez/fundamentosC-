using fundamentals.Models;
using System.Text.Json ;
using System.Text.Json.Serialization;
using System.IO;

namespace fundamentals
{
    class Program
    {
        static async Task Main(string[]args)
        {
            string url = "https://jsonplaceholder.typicode.com/posts";

            HttpClient client = new HttpClient();

            var httpResponse = await client.GetAsync(url);

            if (httpResponse.IsSuccessStatusCode)
            {
                var content = await httpResponse.Content.ReadAsStringAsync();

                List<Models.Post> posts =
                        JsonSerializer.Deserialize<List<Models.Post>>(content);

            }
        }
    }
}