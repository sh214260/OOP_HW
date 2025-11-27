using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EX1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int number = 10;
            long factorial = Math.Factorial(ref number);
            Console.WriteLine($"{number}!={factorial}");
        }
    }
    class Math
    {
        static public long Factorial(ref int number)
        {
            long result = 1;
            for (; number >= 1; number--)
            {
                result *= number;
            }
            return result;
        }
    }

}
