using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CanHazFunny
{   
    interface IOutPutJoke
    {
        public void Print(String Joke);
    }
    internal class Jester
    {
        public static void Print(String Joke) 
        {
            ArgumentNullException.ThrowIfNull(Joke);
            Console.WriteLine(Joke);
        }
    }
}
