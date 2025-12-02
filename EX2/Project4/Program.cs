using System;
using System.Diagnostics;
using System.Threading;

namespace Project4
{
    class Program
    {
        static int[] array;
        static int size = 10_000_000;

        static void Main()
        {
            array = new int[size];

            Console.WriteLine("Case A: Threads accessing different parts of the array");
            Stopwatch swTotalA = Stopwatch.StartNew();

            Thread t1A = new Thread(() => MeasureThreadTime(0, size / 2, "Thread 1A"));
            Thread t2A = new Thread(() => MeasureThreadTime(size / 2, size, "Thread 2A"));

            t1A.Start();
            t2A.Start();
            t1A.Join();
            t2A.Join();

            swTotalA.Stop();
            Console.WriteLine($"Total elapsed time: {swTotalA.ElapsedMilliseconds} ms\n");

            Console.WriteLine("Case B: Threads accessing the entire array");
            Stopwatch swTotalB = Stopwatch.StartNew();

            Thread t1B = new Thread(() => MeasureThreadTime(0, size, "Thread 1B"));
            Thread t2B = new Thread(() => MeasureThreadTime(0, size, "Thread 2B"));

            t1B.Start();
            t2B.Start();
            t1B.Join();
            t2B.Join();

            swTotalB.Stop();
            Console.WriteLine($"Total elapsed time: {swTotalB.ElapsedMilliseconds} ms");
        }

        static void MeasureThreadTime(int start, int end, string name)
        {
            Stopwatch sw = Stopwatch.StartNew();

            for (int i = start; i < end; i++)
            {
                array[i] += 1;  // פעולה פשוטה להדגמה
            }

            sw.Stop();
            Console.WriteLine($"{name} elapsed time: {sw.ElapsedMilliseconds} ms");
        }
    }
}