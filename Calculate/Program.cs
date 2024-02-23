using System.Data;
using static Calculate.Program;

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
    public static void Main()
    {

        string? expression = " ";
        Program program = new();
        Calculator calc = new();
        do
        {
            program.WriteLine("Please Enter Your Expression: or 'q' to exit");
            expression = program.ReadLine();
            if (expression!.Contains("q"))
            {
                program.WriteLine("Exiting");
                break;
            }

            Calculator.TryCalculate(expression!, out int result);
            program.WriteLine(result.ToString("N", System.Globalization.CultureInfo.CurrentCulture));

        } while (Calculator.TryCalculate(expression!, out _) && !expression!.Contains("q"));

    }
}


