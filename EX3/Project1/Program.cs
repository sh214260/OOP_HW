using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1
{
    internal class Program
    {
        public delegate double BinaryOperation(double x, double y);
        public static double Add(double x, double y)
        {
            return x + y;
        }

        public static double Subtract(double x, double y)
        {
            return x - y;
        }

        public static double Multiply(double x, double y)
        {
            return x * y;
        }
        public static double ApplyOperation(BinaryOperation bOp, double a, double b)
        {
            return bOp(a, b);
        }

        static void Main(string[] args)
        {

        }
    }
}
