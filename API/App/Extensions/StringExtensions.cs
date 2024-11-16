using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace API.App.Extensions;

public static class StringExtensions
{
    public static async Task<string> GetAsync(this string url)
    {
        using (var client = new HttpClient())
        {
            var response = await client.GetAsync(url);

            if (response.IsSuccessStatusCode == false) throw new HttpRequestException();

            var body = await response.Content.ReadAsStringAsync();

            return body;
        }
    }

    public static T Deserialize<T>(this string body) where T: class
    {
        var settings = new JsonSerializerSettings
        {
            ContractResolver = new DefaultContractResolver
            {
                NamingStrategy = new SnakeCaseNamingStrategy()
            }
        };

        var result = JsonConvert.DeserializeObject<T>(body, settings);

        return result;
    }
}