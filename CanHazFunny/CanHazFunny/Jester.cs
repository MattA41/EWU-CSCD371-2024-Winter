using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CanHazFunny
{   
    interface IOutPutJoke
    {
        public void Print(String Joke);
    }
    public class Jester
    {
        public static void Print(String Joke) 
        {
            ArgumentNullException.ThrowIfNull(Joke);
            Console.WriteLine(Joke);
        }
        public string TellJoke()
        {
            JokeService jokeGenerator = new JokeService();
            string joke = jokeGenerator.GetJoke();
            while(joke.ToLower().Equals("Chuck Norris".ToLower()))
            {
                joke = jokeGenerator.GetJoke();
            }
            return joke;
        }
    }
}
