using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CanHazFunny; 
    internal interface IOutPutJoke
    {
        public void Print(String Joke);
    }
    public class Jester
    {
        //int Count;
        public static Boolean Print(String Joke) 
        {
            ArgumentNullException.ThrowIfNull(Joke);
            Console.WriteLine(Joke);
            return true;
        }
        public static string TellJoke()
        {
            JokeService jokeGenerator = new();
            string joke = jokeGenerator.GetJoke();
           // int Count = 0;
            while(joke.Contains("Chuck Norris", StringComparison.InvariantCulture))
            {
                joke = jokeGenerator.GetJoke();
              // Count++;
            }
            //Console.WriteLine(Count);
            return joke;
        }
    }
