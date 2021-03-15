using System;

namespace Lessons1
{
    class Program
    {
        public class Fraction
        {
            /// <summary>
            /// Числитель
            /// </summary>
            public int Numerator;
            /// <summary>
            /// Знаменатель
            /// </summary>
            public int Denominator;
            public Fraction(int numerator, int denominator)
            {
                Numerator = numerator;
                Denominator = denominator;
            }
            public Fraction(int numerator)
            {
                Numerator = numerator;
                Denominator = 1;
            }
            public void Print()
            {
                for (int i = 2; i <= Math.Min(Numerator, Denominator); i++)
                {
                    if (Numerator % i == 0 && Denominator % i == 0)
                    {
                        Numerator /= i;
                        Denominator /= i;
                    }
                }
                if (Denominator == 1)
                    Console.WriteLine(Numerator);
                else
                    Console.WriteLine($"{Numerator}/{Denominator}");
            }
            public Fraction Sum(Fraction otherFraction)
            {
                int commonDenominator = Denominator * otherFraction.Denominator;
                int resultNumerator = Numerator * otherFraction.Denominator + otherFraction.Numerator * Denominator;
                Fraction result = new Fraction(resultNumerator, commonDenominator);
                return result;
            }
            public Fraction Difference(Fraction otherFraction)
            {
                int commonDenominator = Denominator * otherFraction.Denominator;
                int resultNumerator = Numerator * otherFraction.Denominator - otherFraction.Numerator * Denominator;
                Fraction result = new Fraction(resultNumerator, commonDenominator);
                return result;
            }
            public Fraction Multiply(Fraction otherFraction)
            {
                Fraction result = new Fraction(Numerator * otherFraction.Numerator, Denominator * otherFraction.Denominator);
                return result;
            }
            public Fraction Divide(Fraction otherFraction)
            {
                Fraction result = new Fraction(Numerator * otherFraction.Denominator, Denominator * otherFraction.Numerator);
                return result;
            }
            public Fraction Sum(int num)
            {
                Fraction otherFraction = new Fraction(num, 1);
                Fraction result = Sum(otherFraction);
                return result;
            }
            public Fraction Difference(int num)
            {
                Fraction otherFraction = new Fraction(num, 1);
                Fraction result = Difference(otherFraction);
                return result;
            }
            public Fraction Multiply(int num)
            {
                Fraction otherFraction = new Fraction(num, 1);
                Fraction result = Multiply(otherFraction);
                return result;
            }
            public Fraction Divide(int num)
            {
                Fraction otherFraction = new Fraction(num, 1);
                Fraction result = Divide(otherFraction);
                return result;
            }
        }
        static void Main(string[] args)
        {
            Fraction fraction1 = new Fraction(1, 2);
            fraction1.Print();

            Fraction result = fraction1.Sum(1);
            result.Print(); // 3/2

            result = fraction1.Difference(1);
            result.Print(); // -1/2

            result = fraction1.Multiply(2);
            result.Print(); // 2/2

            result = fraction1.Divide(2);
            result.Print(); // 1/4

            Fraction fraction3 = new Fraction(1000000, 600000);
            fraction3.Print();
        }
    }
}
