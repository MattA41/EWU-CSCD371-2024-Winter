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
    public void Test_TellJoke_JokeContainsChuckNorris_GetsNewJoke()
    {
        // Arrange
        var jokeServiceMock = new Mock<IJokeServiceInterface>();
        jokeServiceMock.SetupSequence(j => j.GetJoke())
            .Returns("Chuck Norris joke")
            .Returns("Another Chuck Norris joke")
            .Returns("A regular joke");

        var outputMock = new Mock<IOutPutJoke>();

        var jester = new Jester(jokeServiceMock.Object, outputMock.Object);

        // Act
        string result = jester.TellJoke();

        // Assert
        outputMock.Verify(o => o.Print("A regular joke"), Times.Once);
        Assert.Equal("A regular joke", result);
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
    public void Test_NullOutputService_ThrowsException()
    {
        Assert.Throws<ArgumentNullException>(() => new Jester(Mock.Of<IJokeServiceInterface>(), null!));
    }
    [Fact]
    public void Test_NullJokeService_ThrowsException()
    {
        Assert.Throws<ArgumentNullException>(() => new Jester(null!, Mock.Of<IOutPutJoke>()));
    }
    [Fact]
    public void Test_BothNull_ThrowsException()
    {
        Assert.Throws<ArgumentNullException>(() => new Jester(null!,null!));
    }
    [Fact]
    public void Test_ValidInput()
    {
        var jester = new Jester(Mock.Of<IJokeServiceInterface>(), Mock.Of<IOutPutJoke>());
        Assert.NotNull(jester);
    }
}
