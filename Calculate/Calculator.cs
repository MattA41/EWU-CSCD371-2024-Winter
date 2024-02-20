using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculate
{
    public class Calculator
    {
        //private IReadOnlyDictionary<TKey, TValue> MathematicalOperations;

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
            return one / two;
        }
        

    }
}
