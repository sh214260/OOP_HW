using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project4
{
    class Program
    {
        static void Main()
        {
            Fraction f1 = new Fraction(2, 3);
            Fraction f2 = new Fraction(3, 4);

            // Print the two fractions before operations (in English)
            Console.Write("First fraction: ");
            f1.Print();
            Console.Write("Second fraction: ");
            f2.Print();

            Console.Write("Sum: ");
            (f1 + f2).Print();

            Console.Write("Difference: ");
            (f1 - f2).Print();

            Console.Write("Product: ");
            (f1 * f2).Print();

            Console.Write("Quotient: ");
            (f1 / f2).Print();

            Console.WriteLine($"Are they equal? {f1 == f2}");
            Console.WriteLine($"Is f1 greater than f2? {f1 > f2}");
        }
    }
    public class Fraction
    {
        private int numerator;
        private int denominator;

        public Fraction(int numerator, int denominator)
        {
            if (denominator == 0)
            {
                Console.WriteLine("Error: Denominator cannot be zero. Defaulting to 1.");
                denominator = 1;
            }

            int gcd = GCD(Math.Abs(numerator), Math.Abs(denominator));
            this.numerator = numerator / gcd;
            this.denominator = denominator / gcd;
        }

        public int Numerator => numerator;
        public int Denominator => denominator;
        public override string ToString()
        {
            return $"{numerator}/{denominator}";
        }

        public void Print()
        {
            Console.WriteLine($"{numerator}/{denominator}");
        }

        private int GCD(int a, int b)
        {
            while (b != 0)
            {
                int temp = b;
                b = a % b;
                a = temp;
            }
            return a;
        }

        // Addition
        public static Fraction operator +(Fraction a, Fraction b)
        {
            int commonDenominator = a.denominator * b.denominator;
            int newNumerator = a.numerator * b.denominator + b.numerator * a.denominator;
            return new Fraction(newNumerator, commonDenominator);
        }

        // Subtraction
        public static Fraction operator -(Fraction a, Fraction b)
        {
            int commonDenominator = a.denominator * b.denominator;
            int newNumerator = a.numerator * b.denominator - b.numerator * a.denominator;
            return new Fraction(newNumerator, commonDenominator);
        }

        // Multiplication
        public static Fraction operator *(Fraction a, Fraction b)
        {
            return new Fraction(a.numerator * b.numerator, a.denominator * b.denominator);
        }

        // Division
        public static Fraction operator /(Fraction a, Fraction b)
        {
            return new Fraction(a.numerator * b.denominator, a.denominator * b.numerator);
        }

        // Equality
        public static bool operator ==(Fraction a, Fraction b)
        {
            return a.numerator == b.numerator && a.denominator == b.denominator;
        }

        public static bool operator !=(Fraction a, Fraction b)
        {
            return !(a == b);
        }

        // Comparison
        public static bool operator <(Fraction a, Fraction b)
        {
            return a.numerator * b.denominator < b.numerator * a.denominator;
        }

        public static bool operator >(Fraction a, Fraction b)
        {
            return a.numerator * b.denominator > b.numerator * a.denominator;
        }

        // Required overrides for == and !=
        public override bool Equals(object obj)
        {
            if (obj is Fraction other)
                return this == other;
            return false;
        }

        public override int GetHashCode()
        {
            return numerator.GetHashCode() ^ denominator.GetHashCode();
        }
}        
    
}    



