using System;
using Moq;
using Newtonsoft.Json.Bson;
using Xunit;
using Xunit.Sdk;

namespace CanHazFunny.Tests;

public class JesterTests
{
    [Fact]
    public void Test_TellJoke_Not_Norris()
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
    public void Test_TellJoke_CheckNotNull()
    {
        var jokeServiceMock = new Mock<IJokeServiceInterface>();
        jokeServiceMock.Setup(j => j.GetJoke()).Returns("A regular joke");

        var outputJokeMock = new Mock<IOutPutJoke>();

        var jester = new Jester(jokeServiceMock.Object, outputJokeMock.Object);
        string joke = jester.TellJoke();
        Assert.NotNull(joke);
    }
    [Fact]
    public void Test_JesterPrint_NullInput()
    {
        var jokeServiceMock = new Mock<IJokeServiceInterface>();
        jokeServiceMock.Setup(j => j.GetJoke()).Returns("A regular joke");

        var outputJokeMock = new Mock<IOutPutJoke>();

        var jester = new Jester(jokeServiceMock.Object, outputJokeMock.Object);

        Assert.Throws<ArgumentNullException>(() => Jester.Print(null!));

    }
    [Fact]
    public void Test_JesterPrint_GoodInput()
    {
        var jokeServiceMock = new Mock<IJokeServiceInterface>();
        jokeServiceMock.Setup(j => j.GetJoke()).Returns("A regular joke");

        var outputJokeMock = new Mock<IOutPutJoke>();

        var jester = new Jester(jokeServiceMock.Object, outputJokeMock.Object);
        Assert.True(Jester.Print("this is a joke"));
    }
}
