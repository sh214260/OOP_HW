using System;

class Program
{
    static void Main()
    {
        long step = 10_000_000; // נעלה כל פעם ב־10 מיליון תאים
        for (long size = step; size < int.MaxValue; size += step)
        {
            try
            {
                Console.Write($"מנסה להקצות מערך בגודל {size:N0} ... ");
                int[] arr = new int[size];
                Console.WriteLine("הצליח");
            }
            catch (OutOfMemoryException)
            {
                Console.WriteLine("נכשל – OutOfMemoryException");
                break;
            }
        }
    }
}
