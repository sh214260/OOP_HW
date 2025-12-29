using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project2
{
    public class ArrayProcessor
    {
        // הגדרת הדלגייט
        public delegate void UnaryAction(double a);

        // פונקציה שמקבלת מערך ודלגייט ומפעילה את הדלגייט על כל איבר
        public static void ProcessArray(double[] array, UnaryAction processor)
        {
            foreach (double item in array)
            {
                processor(item);
            }
        }
    }

    // מחלקה לחישוב סכום
    public class SumCalculator
    {
        public double Sum { get; private set; } = 0;

        public void AddToSum(double value)
        {
            Sum += value;
        }
    }

    // מחלקה לחישוב מקסימום
    public class MaxCalculator
    {
        public double Max { get; private set; } = double.MinValue;

        public void CheckMax(double value)
        {
            if (value > Max)
                Max = value;
        }
    }
    internal class Program
    {

        static void Main(string[] args)
        {
            Random rnd = new Random();
            double[] numbers = new double[10];

            // יצירת מערך אקראי
            for (int i = 0; i < numbers.Length; i++)
            {
                numbers[i] = rnd.NextDouble() * 100; // מספרים בין 0 ל-100
                Console.WriteLine($"numbers[{i}] = {numbers[i]:F2}");
            }

            // חישוב סכום באמצעות מחלקה
            SumCalculator sumCalc = new SumCalculator();
            ArrayProcessor.ProcessArray(numbers, sumCalc.AddToSum);
            Console.WriteLine($"Sum using class: {sumCalc.Sum:F2}");

            // חישוב מקסימום באמצעות מחלקה
            MaxCalculator maxCalc = new MaxCalculator();
            ArrayProcessor.ProcessArray(numbers, maxCalc.CheckMax);
            Console.WriteLine($"Max using class: {maxCalc.Max:F2}");

            // חישוב סכום באמצעות Lambda closure
            double sumLambda = 0;
            ArrayProcessor.ProcessArray(numbers, x => sumLambda += x);
            Console.WriteLine($"Sum using lambda: {sumLambda:F2}");

            // חישוב מקסימום באמצעות Lambda closure
            double maxLambda = double.MinValue;
            ArrayProcessor.ProcessArray(numbers, x =>
            {
                if (x > maxLambda) maxLambda = x;
            });
            Console.WriteLine($"Max using lambda: {maxLambda:F2}");

        }
    }
}
