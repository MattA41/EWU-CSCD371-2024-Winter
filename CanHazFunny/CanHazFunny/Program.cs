using System;

namespace CanHazFunny;

public class Program
{
    public static void Main()
    {
        //ArgumentNullException.ThrowIfNull(args);
        //Feel free to use your own setup here - this is just provided as an example
        //new Jester(new SomeReallyCoolOutputClass(), new SomeJokeServiceClass()).TellJoke();
       OutputService outputService = new();
        JokeService jokeService = new();
        Jester jest = new(jokeService, outputService);
        jest.TellJoke();
        
    }
}
