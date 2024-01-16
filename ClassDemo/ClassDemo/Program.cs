

namespace ClassDemo;

public class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
    }

    public bool TryLogin(string username, string password)
    {
        if ((username == "Inigo.Montoya" || username == "Princess.Buttercup" || username == "Count.Rugen") && password == "goodpassword")
        {
            return true;
        }
        return false;
    }
    public bool Login(string username, string password)
    {
       if(!TryLogin(username, password))
        {
            throw new InvalidOperationException();

        }
        return true;
    }
}
