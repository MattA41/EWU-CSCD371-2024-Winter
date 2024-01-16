// TestProjectName.Tests
namespace ClassDemo.Tests;

// ClassNameTests
public class ProgramTests
{
    Program Program { get; set; }

    public ProgramTests()
    {
        Program = TestInitialize();
    }

    int _InstanceCount = 0;

    private static Program TestInitialize()
    {
        return new Program();
    }
    [Theory]
    [InlineData("Inigo.Montoya", "goodpassword")]
    [InlineData("Princess.Buttercup", "goodpassword")]
    [InlineData("Count.Rugen", "goodpassword")]
    public void TryLogin_WithGoodPassword_SucessfulLogin(string username, string password)
    {
        Assert.True(Program.TryLogin(username, password)); 
    }

    [Fact]
    // MethodUnderTest_ConditionUnderTest_ExpectedResult
    public void Login_InigoMontoyaWithGoodPassword_SuccessfulLogin()
    {
        Assert.Equal(0, _InstanceCount);
        _InstanceCount++;
        Assert.True(Program.TryLogin("Inigo.Montoya", "goodpassword"));
    }

    [Fact]
    public void Login_InigoMontoyaWithGoodPassword_FailedLogin()
    {
        Assert.Equal(0, _InstanceCount);
        _InstanceCount++;
        Assert.False(Program.TryLogin("Inigo.Montoya", "badpassword"));
    }
    [Fact]
    public void Login_PrincessButtercupWithGoodPassword_SuccessfulLogin()
    {
        Assert.Equal(0, _InstanceCount);
        _InstanceCount++;
        Assert.True(Program.TryLogin(username: "Princess.Buttercup", password: "goodpassword"));

    }
    [Fact]
    public void Login_PrincessButtercupWithBadPassword_FailedLogin()
    {
        Assert.Throws<InvalidOperationException>(() => Program.Login(username: "Princess.Buttercup", password: "badpassword"));

    }
    
 



}