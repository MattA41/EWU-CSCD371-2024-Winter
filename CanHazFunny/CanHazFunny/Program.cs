using System;

namespace CanHazFunny;

public class Program
{
    public static void Main(string[] args)
    {
        //ArgumentNullException.ThrowIfNull(args);
        //Feel free to use your own setup here - this is just provided as an example
        //new Jester(new SomeReallyCoolOutputClass(), new SomeJokeServiceClass()).TellJoke();
       OutputService outputService = new OutputService();
        JokeService jokeService = new JokeService();
        Jester jest = new Jester(jokeService, outputService);
        jest.TellJoke();
        
    }
}
