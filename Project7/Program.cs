using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project7
{
    using System;

    struct PointStruct
    {
        public int X;
        public int Y;
    }

    class Program
    {
        static int counter = 0;
        static int maxCounter = 0;

        // פונקציה רקורסיבית
        static void Recursion(int arraySize, int numPoints)
        {
            // מערך בגודל arraySize
            int[] arr = new int[arraySize];

            // משתנים מסוג Struct לפי numPoints
            PointStruct[] points = new PointStruct[numPoints];

            counter++;
            if (counter % 1000 == 0) // מדפיס כל 1000 קריאות
                Console.WriteLine($"counter = {counter}");

            Recursion(arraySize, numPoints);
        }

        static void Test(int arraySize, int numPoints)
        {
            counter = 0;
            try
            {
                Recursion(arraySize, numPoints);
            }
            catch (StackOverflowException)
            {
                // StackOverflow נזרק - שומרים את הערך המקסימלי שהגענו אליו
                maxCounter = counter;
                Console.WriteLine($"StackOverflow! arraySize={arraySize}, numPoints={numPoints}, maxCounter={maxCounter}");
            }
        }

        static void Main()
        {
            Console.WriteLine("Starting StackOverflow experiments...");

            // טבלה עם 3 אפשרויות שונות
            Test(10, 4);   // מערך קטן, כמה Structs
            Test(100, 4);  // מערך גדול יותר, אותו מספר Structs
            Test(10, 8);   // מערך קטן, יותר Structs
            Test(100, 8);  // מערך גדול, יותר Structs

            Console.WriteLine("Experiments finished.");
        }
    }

}
