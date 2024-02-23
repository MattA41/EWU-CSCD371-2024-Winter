using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculate;
public class Calculator
{
    public static IReadOnlyDictionary<char, Func<int, int, int>> MathematicalOperations { get; } = new Dictionary<char, Func<int, int, int>>
        {
             { '+', Add},
             { '-' , Subtract },
             { '/', Divide },
               {'*', Multiple }
        };

    public static int Add(int one, int two)
    {
        return one + two;
    }

    public static int Subtract(int one, int two)
    {
        return one - two;
    }
    public static int Multiple(int one, int two)
    {
        return one * two;
    }

    public static int Divide(int one, int two)
    {
        if (two == 0)
        {
            throw new ArgumentException("Cant divide by 0");
        }
        return one / two;
    }

    public  bool TryCalculate(string expression, out int result)
    {
        result = 0;
        string[] input = expression.Split(" ");
        if (input.Length != 3)
        {
            return false;

        }
        if (int.TryParse(input[0], out int numOne) && int.TryParse(input[2], out int numtwo))
        {
            if (MathematicalOperations.TryGetValue(input[1][0], out Func<int, int, int>? operand))
            {
                result = operand(numOne, numtwo);
                return true;
            }
            return false;
        }
        else
        {
            return false;
        }


    }

}

