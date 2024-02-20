namespace Calculate;
public class Program
{
    public delegate void WriteLineDelegate(string text);
    public delegate string? ReadLineDelegate();


    public WriteLineDelegate WriteLine { get; init; }
    public ReadLineDelegate ReadLine { get; init; }


    public Program()
    {
        WriteLine ??= Console.WriteLine;
        ReadLine ??= Console.ReadLine;
    }
    public static void Main(string[] args)
    {

        string? expression = "Test";
        Program program = new();
        do
        {
            program.WriteLine("Please Enter Your Expression: ");
            expression = program.ReadLine();
            Calculator.TryCalculate(expression!, out int result);
            program.WriteLine(result.ToString());

        } while (Calculator.TryCalculate(expression!, out int res));

    }
}


