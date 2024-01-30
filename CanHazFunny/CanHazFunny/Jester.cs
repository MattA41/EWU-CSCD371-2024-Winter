using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CanHazFunny; 
    public interface IOutPutJoke
    {
        public void Print(String Joke);
    }
    public class Jester(IJokeServiceInterface jokeService, IOutPutJoke output)
{
    private readonly IJokeServiceInterface jokeService = jokeService ?? throw new ArgumentNullException(nameof(jokeService));
    private readonly IOutPutJoke output = output ?? throw new ArgumentNullException(nameof(output));

    public static Boolean Print(String Joke) 
        {
            ArgumentNullException.ThrowIfNull(Joke);
            Console.WriteLine(Joke);
            return true;
        }
    public string TellJoke()
    {
        string joke = jokeService.GetJoke();

        while (joke.Contains("Chuck Norris", StringComparison.InvariantCulture))
        {
            joke = jokeService.GetJoke();
        }

        output.Print(joke);
        return joke;
    }
}
