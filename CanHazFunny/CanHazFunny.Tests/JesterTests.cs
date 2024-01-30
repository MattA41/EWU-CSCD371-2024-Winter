using System;
using Newtonsoft.Json.Bson;
using Xunit;
using Xunit.Sdk;

namespace CanHazFunny.Tests;

public class JesterTests
{
    [Fact]
    public void TellJoke_Not_Norris()
    {
        string joke = Jester.TellJoke();
        Assert.DoesNotContain("Chuck Norris".ToLowerInvariant(), joke.ToLowerInvariant());
    }
    [Fact]
    public void TellJoke_CheckNotNull()
    {
        string joke = Jester.TellJoke();
        Assert.NotNull(joke);
    }
    [Fact]
    public void Joke_TestPrint()
    {
        Assert.Throws<ArgumentNullException>(() => Jester.Print(null));
    }

}
