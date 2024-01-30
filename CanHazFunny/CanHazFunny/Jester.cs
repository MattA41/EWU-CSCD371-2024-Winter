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
    public class Jester
    {
    private readonly IJokeServiceInterface jokeService;
    private readonly IOutPutJoke output;

    public Jester(IJokeServiceInterface jokeService, IOutPutJoke output)
    {
        this.jokeService = jokeService ?? throw new ArgumentNullException(nameof(jokeService));
        this.output = output ?? throw new ArgumentNullException(nameof(output));
    }

    public Boolean Print(String Joke) 
        {
            ArgumentNullException.ThrowIfNull(joke);
            Console.WriteLine(joke);
            //return true;
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
