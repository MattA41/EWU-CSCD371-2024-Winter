using System;

namespace CanHazFunny;

public class Program
{
    public static void Main()
    {
        OutputService outputService = new();
        JokeService jokeService = new();
        Jester jest = new(jokeService, outputService);
        jest.TellJoke();

    }
}
