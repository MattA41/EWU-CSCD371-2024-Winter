// TestProjectName.Tests
namespace ClassDemo.Tests;

// ClassNameTests
public class ProgramTests
{
    Program _Program;

    public ProgramTests()
    {
        _Program = TestInitialize();
    }

    int _InstanceCount = 0;

    private static Program TestInitialize()
    {
        return new Program();
    }

    [Fact]
    // MethodUnderTest_ConditionUnderTest_ExpectedResult
    public void Login_InigoMontoyaWithGoodPassword_SuccessfulLogin()
    {
        Assert.Equal(0, _InstanceCount);
        string username = "Inigo.Montoya";
        string password = "goodpassword";
        _InstanceCount ++;

        Assert.True(_Program.Login(username, password));
    }

    [Fact]
    public void Login_InigoMontoyaWithGoodPassword_FailedLogin()
    {
        Assert.Equal(0, _InstanceCount);
        _InstanceCount++;

        Assert.False(_Program.Login("Inigo.Montoya", "badpassword"));
    }

    [Fact]
    public void Login_PrincessButtercupWithGoodPassword_SuccessfulLogin()
    {
        Assert.True(_Program.Login("Princess.Buttercup", "goodpassword"));
    }


}