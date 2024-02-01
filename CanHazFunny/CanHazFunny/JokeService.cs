using System.Net.Http;

namespace CanHazFunny;

public class JokeService : IJokeServiceInterface
{
    private HttpClient HttpClient { get; } = new();

    public string GetJoke()
    {
        HttpResponseMessage json = HttpClient.GetAsync("https://geek-jokes.sameerkumar.website/api").Result;
        string joke = json.Content.ReadAsStringAsync().Result;
        return joke;
    }
}
