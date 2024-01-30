using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CanHazFunny; 
    interface IOutPutJoke
    {
        public void Print(String Joke);
    }
    public class Jester
    {
        //int Count;
        public static void Print(String Joke) 
        {
            ArgumentNullException.ThrowIfNull(Joke);
            Console.WriteLine(Joke);
        }
        public static string TellJoke()
        {
            JokeService jokeGenerator = new();
            string joke = jokeGenerator.GetJoke();
           // int Count = 0;
            while(joke.ToLower().Contains("Chuck Norris".ToLower()))
            {
                joke = jokeGenerator.GetJoke();
              // Count++;
            }
            //Console.WriteLine(Count);
            return joke;
        }
    }
