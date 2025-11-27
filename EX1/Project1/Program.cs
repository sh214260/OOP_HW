using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1
{
    struct MyStruct
    {
        public int Value;
    }

    class MyClass
    {
        public int Value;
    }
    internal class Program
    {
        // פונקציה שמקבלת struct כ-reference ומעדכנת אותו
        static void ModifyStruct(ref MyStruct s)
        {
            s.Value = 999;
        }

        // פונקציה שמקבלת class ומעדכנת אותו
        static void ModifyClass(MyClass c)
        {
            c.Value = 999;
        }

        static void Main()
        {
            Console.WriteLine("=== assisment ===");

            // --- Struct ---
            MyStruct s1 = new MyStruct { Value = 10 };
            MyStruct s2 = s1;  // העתקה
            s2.Value = 20;
            Console.WriteLine($"Struct: s1.Value={s1.Value}, s2.Value={s2.Value}");
            // תוצאה: s1 נשאר 10, s2=20

            // --- Class ---
            MyClass c1 = new MyClass { Value = 10 };
            MyClass c2 = c1;  // reference
            c2.Value = 20;
            Console.WriteLine($"Class: c1.Value={c1.Value}, c2.Value={c2.Value}");
            // תוצאה: c1=20, c2=20

            Console.WriteLine("\n=== function ===");

            // --- Struct ---
            MyStruct s3 = new MyStruct { Value = 30 };
            ModifyStruct(ref s3); // ref כדי לשנות את המקור
            Console.WriteLine($"Struct after ref modify: s3.Value={s3.Value}");
            // תוצאה: s3.Value=999

            // --- Class ---
            MyClass c3 = new MyClass { Value = 30 };
            ModifyClass(c3); // אין צורך ב-ref
            Console.WriteLine($"Class after modify: c3.Value={c3.Value}");
            // תוצאה: c3.Value=999
        }
    }
}

