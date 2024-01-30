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
    public void JokePrint_NullInput()
    {
#pragma warning disable CS8625 // Cannot convert null literal to non-nullable reference type. Disabled to test the method works as intended when a null opject is passed in
        Assert.Throws<ArgumentNullException>(() => Jester.Print(null));
#pragma warning restore CS8625 // Cannot convert null literal to non-nullable reference type.
    }
    [Fact]
    public void Test_JokePrint_ValidInput()
    {
        Assert.True(Jester.Print("this is a joke"));
    }
}
