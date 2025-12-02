using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project3
{
    internal class Program
    {
        //section1
        void Swap(int[] arr, int i, int j)
        {
            int temp = arr[i];
            arr[i] = arr[j];
            arr[j] = temp;
        }
        //section2
        void SwapGeneric<T>(ref T a, ref T b)
        {
            T temp = a;
            a = b;
            b = temp;
        }


        static void Main(string[] args)
        {
        }
    }
}
