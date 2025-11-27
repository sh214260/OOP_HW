using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project6
{

    internal class Program
    {
        // פונקציה למדידת זיכרון שהוקצה
        public static long GetObjectSize(Action allocationAction)
        {
            long before = GC.GetAllocatedBytesForCurrentThread();
            allocationAction();
            long after = GC.GetAllocatedBytesForCurrentThread();
            return after - before;
        }

        // structs בגדלים שונים
        struct SmallStruct { public int a; }
        struct MediumStruct { public int a; public double b; }
        struct LargeStruct { public int a; public double b; public long c; }

        // classes בגדלים שונים
        class SmallClass { public int a; }
        class MediumClass { public int a; public double b; }
        class LargeClass { public int a; public double b; public long c; }

        static void Main()
        {
            Console.WriteLine("=== Empty array ===");
            Console.WriteLine($"int[] empty: {GetObjectSize(() => { int[] arr = new int[0]; })} bytes");
            Console.WriteLine($"double[] empty: {GetObjectSize(() => { double[] arr = new double[0]; })} bytes");
            Console.WriteLine($"string[] empty: {GetObjectSize(() => { string[] arr = new string[0]; })} bytes");

            Console.WriteLine("\n=== structs array ===");
            int n = 10000;
            long smallStructArray = GetObjectSize(() => { SmallStruct[] arr = new SmallStruct[n]; });
            long mediumStructArray = GetObjectSize(() => { MediumStruct[] arr = new MediumStruct[n]; });
            long largeStructArray = GetObjectSize(() => { LargeStruct[] arr = new LargeStruct[n]; });

            Console.WriteLine($"SmallStruct[{n}]: {smallStructArray} bytes");
            Console.WriteLine($"MediumStruct[{n}]: {mediumStructArray} bytes");
            Console.WriteLine($"LargeStruct[{n}]: {largeStructArray} bytes");

            Console.WriteLine("\n=== classes array ===");
            long smallClassArray = GetObjectSize(() =>
            {
                SmallClass[] arr = new SmallClass[n];
                for (int i = 0; i < n; i++)
                    arr[i] = new SmallClass();
            });

            long mediumClassArray = GetObjectSize(() =>
            {
                MediumClass[] arr = new MediumClass[n];
                for (int i = 0; i < n; i++)
                    arr[i] = new MediumClass();
            });

            long largeClassArray = GetObjectSize(() =>
            {
                LargeClass[] arr = new LargeClass[n];
                for (int i = 0; i < n; i++)
                    arr[i] = new LargeClass();
            });

            Console.WriteLine($"SmallClass[{n}]: {smallClassArray} bytes");
            Console.WriteLine($"MediumClass[{n}]: {mediumClassArray} bytes");
            Console.WriteLine($"LargeClass[{n}]: {largeClassArray} bytes");
        }
    }

}
