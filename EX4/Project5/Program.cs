using Project4;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project5
{
    internal class Program
    {
        public class GenericOperationTable<T>
        {
            private Func<T, T, T> operation;

            public GenericOperationTable(Func<T, T, T> operation)
            {
                this.operation = operation;
            }

            public void PrintTable(List<T> values)
            {
                Console.Write("     ");
                foreach (var col in values)
                {
                    Console.Write($"{col,8}");
                }
                Console.WriteLine();

                foreach (var row in values)
                {
                    Console.Write($"{row,5}");
                    foreach (var col in values)
                    {
                        var result = operation(row, col);
                        Console.Write($"{result,8}");
                    }
                    Console.WriteLine();
                }
            }
        }

        static void Main()
        {
            List<Fraction> fractions = new List<Fraction>();
            for (int i = 1; i <= 12; i++)
            {
                fractions.Add(new Fraction(i, 12));
            }

            var additionTable = new GenericOperationTable<Fraction>((a, b) => a + b);
            Console.WriteLine("Fraction Addition Table:");
            additionTable.PrintTable(fractions);
        }

    }
}
