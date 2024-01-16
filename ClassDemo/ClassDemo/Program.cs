namespace ClassDemo;
public class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
    }
    public bool Login(string username, string password)
    {
        //throw new NotImplementedException();
        if((username == "Inigo.Montoya" || username == "Princess.Buttercup") && password == "goodpassword")
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
