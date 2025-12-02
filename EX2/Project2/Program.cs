using System;
using System.Diagnostics;

namespace Project2
{
    class Program
    {
        static void Main()
        {
            const int N = 50_000_000;
            int[] arr = new int[N];

            for (int i = 0; i < arr.Length; i++)
                arr[i] = i;

            var sw = new Stopwatch();

            // 1. גישה רציפה
            long sum1 = 0;
            sw.Start();
            for (int i = 0; i < arr.Length; i++)
                sum1 += arr[i];
            sw.Stop();
            Console.WriteLine($"גישה רציפה: {sw.ElapsedMilliseconds} ms");

            // 2. גישה מרוחקת (קפיצה כל stride)
            foreach (int stride in new[] { 2, 4, 8, 16, 64, 256, 1024, 4096 })
            {
                long sum2 = 0;
                sw.Restart();
                for (int i = 0; i < arr.Length; i += stride)
                    sum2 += arr[i];
                sw.Stop();

                Console.WriteLine($"גישה בקפיצות (stride={stride}): {sw.ElapsedMilliseconds} ms");
            }
        }
    }
}
