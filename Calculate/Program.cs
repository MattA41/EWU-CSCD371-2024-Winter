using static Calculate.Program;

using
namespace Calculate;

public class Program
{
    public delegate void DelegateWriteLine(string text);
    public delegate string? DelegateReadLine();


    public DelegateWriteLine WriteLine { get; init; }
    public DelegateReadLine ReadLine { get; init; }


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
            program.WriteLine(result.ToString(IFormatProvider));

        } while (Calculator.TryCalculate(expression!, out int res));

    }
}


