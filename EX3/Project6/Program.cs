using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project6
{
    using System;

    public class OperationTable
    {
        private int startRow, endRow;
        private int startCol, endCol;
        private Func<int, int, int> operation;

        public OperationTable(int startRow, int endRow, int startCol, int endCol, Func<int, int, int> operation)
        {
            this.startRow = startRow;
            this.endRow = endRow;
            this.startCol = startCol;
            this.endCol = endCol;
            this.operation = operation;
        }

        public void Print()
        {
            // הדפסת כותרת העמודות
            Console.Write("     ");
            for (int col = startCol; col <= endCol; col++)
            {
                Console.Write($"{col,5}");
            }
            Console.WriteLine();

            // הדפסת השורות
            for (int row = startRow; row <= endRow; row++)
            {
                Console.Write($"{row,5}");
                for (int col = startCol; col <= endCol; col++)
                {
                    int result = operation(row, col);
                    Console.Write($"{result,5}");
                }
                Console.WriteLine();
            }
        }
    }

    class Program
    {
        static void Main()
        {
            // פעולה של כפל
            Func<int, int, int> multiply = (x, y) => x * y;

            OperationTable table = new OperationTable(1, 10, 1, 10, multiply);
            table.Print();
        }
    }

}
