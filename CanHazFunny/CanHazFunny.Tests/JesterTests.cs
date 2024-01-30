using System;
using Moq;
using Newtonsoft.Json.Bson;
using Xunit;
using Xunit.Sdk;

namespace CanHazFunny.Tests;

public class JesterTests
{
    [Fact]
    public void TellJoke_Not_Norris()
    {
        var jokeServiceMock = new Mock<IJokeServiceInterface>();
        jokeServiceMock.Setup(j => j.GetJoke()).Returns("A regular joke");

        var outputJokeMock = new Mock<IOutPutJoke>();

        var jester = new Jester(jokeServiceMock.Object, outputJokeMock.Object);

        string joke = jester.TellJoke();

        // Assert
        outputJokeMock.Verify(o => o.Print(It.IsAny<string>()), Times.Once);
        Assert.Equal("A regular joke", joke);
    }
    [Fact]
    public void TellJoke_CheckNotNull()
    {
        var jokeServiceMock = new Mock<IJokeServiceInterface>();
        jokeServiceMock.Setup(j => j.GetJoke()).Returns("A regular joke");

        var outputJokeMock = new Mock<IOutPutJoke>();

        var jester = new Jester(jokeServiceMock.Object, outputJokeMock.Object);
        string joke = jester.TellJoke();
        Assert.NotNull(joke);
    }
    [Fact]
    public void JokePrint_NullInput()
    {
        var jokeServiceMock = new Mock<IJokeServiceInterface>();
        jokeServiceMock.Setup(j => j.GetJoke()).Returns("A regular joke");

        var outputJokeMock = new Mock<IOutPutJoke>();

        var jester = new Jester(jokeServiceMock.Object, outputJokeMock.Object);
#pragma warning disable CS8625 // Cannot convert null literal to non-nullable reference type. Disabled to test the method works as intended when a null opject is passed in
        Assert.Throws<ArgumentNullException>(() => jester.Print(null));
#pragma warning restore CS8625 // Cannot convert null literal to non-nullable reference type.
    }
    [Fact]
    public void Test_JokePrint_ValidInput()
    {
        var jokeServiceMock = new Mock<IJokeServiceInterface>();
        jokeServiceMock.Setup(j => j.GetJoke()).Returns("A regular joke");

        var outputJokeMock = new Mock<IOutPutJoke>();

        var jester = new Jester(jokeServiceMock.Object, outputJokeMock.Object);
        Assert.True(jester.Print("this is a joke"));
    }
}
