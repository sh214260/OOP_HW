using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project7
{
    using System;
    using System.Collections.Generic;

    public class OperationTable<T>
    {
        public delegate T OpFunc(T x, T y);
        public OpFunc op;

        private List<T> rowValues;
        private List<T> colValues;
        private T[,] table;

        public OperationTable(List<T> _row_values, List<T> _col_values, OpFunc _op)
        {
            rowValues = _row_values;
            colValues = _col_values;
            op = _op;

            int rows = rowValues.Count;
            int cols = colValues.Count;
            table = new T[rows, cols];

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    table[i, j] = op(rowValues[i], colValues[j]);
                }
            }
        }

        public void Print()
        {
            Console.Write("     ");
            foreach (var col in colValues)
            {
                Console.Write($"{col,10}");
            }
            Console.WriteLine();

            for (int i = 0; i < rowValues.Count; i++)
            {
                Console.Write($"{rowValues[i],5}");
                for (int j = 0; j < colValues.Count; j++)
                {
                    Console.Write($"{table[i, j],10}");
                }
                Console.WriteLine();
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            List<double> row_values = new List<double>();
            for (int i =1; i <= 4; i++)
            {
                row_values.Add(1.0 / i);
            }

            List<double> col_values = new List<double>();
            for (int i = 1; i < 5; i++)
            {
                col_values.Add(1.0 / i);
            }

            OperationTable<double> t1 =
                new OperationTable<double>(row_values, col_values, (x, y) => x + y);

            t1.Print();
        }

    }

}
