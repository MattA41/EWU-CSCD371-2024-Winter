namespace ClassDemo.Tests;

public class ProgramTests
{
    // If wanted to do cleanup run it before initalizing
    Program _Program = new Program();
    // we dont need the instance count method just used in class to show it re-intitalize every time
    int _InstanceCount = 0;
    [Fact]
    public void Login_inigoMontoyaWithGoodPassword_SuccsessfulLogin()
    {
        Assert.Equal(0, _InstanceCount);
        string username = "Inigo.Montoya";
        string password =  "goodpassword";

        _InstanceCount++;

        Assert.True(_Program.Login(username, password));
        
    }
    
    [Fact]
    public void Login_IntigoMontoyaWithGoodPassword_FailedLogin()
    {
        Assert.Equal(0, _InstanceCount);
        string username = "Intigo.Montoya";
        string password = "badpassword";
        
        _InstanceCount++;
        
        Assert.False(_Program.Login(username, password));
    }

    [Fact]
    public void Login_PrincessButtercupWithGoodPassword_SuccsessfulLogin()
    {
        string username = "Princess.Buttercup";
        string password = "goodpassword";

        Assert.True( _Program.Login(username, password));
    }
    [Fact]
    public void Login_PrincessbuttercupWithGoodPassword_FailedLogin()
    {
        string username = "Princess.Buttercup";
        string password = "goodpassword";
        Assert.False( _Program.Login(username, password));
    }
}