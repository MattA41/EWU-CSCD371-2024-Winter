namespace ClassDemo.Tests;

public class ProgramTests
{
    Program _Program = new Program();

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
}