namespace Calculate;
public class Program
{
    public delegate void WriteLineDelegate(string text);
    public delegate string ReadLineDelegate();


    public WriteLineDelegate WriteLine { get; init; }
    public ReadLineDelegate ReadLine { get; init; }


    public Program()
    {
        WriteLine ??= Console.WriteLine;
        ReadLine ??= Console.ReadLine;
    }

}
