using System;

namespace RecursionHometask
{
    class Program
    {
        static void arrayOutput(int[] array, int i = 0) //вывод массива
        {

            if (i < array.Length)
            {
                Console.WriteLine(array[i]);
                i++;
                arrayOutput(array, i);
            }
            else
            {
                return;
            }
        }
        static void arraySum(int[] array, int i = 0, int cnt = 0) //сумма элементов массива
        {
            
            if (i < array.Length)
            {
                cnt += array[i];
                i++;
                arraySum(array, i, cnt);
            }
            else
            {
                Console.WriteLine(cnt);
                return;
            }
        }

        static int Sum(int[] array, int i = 0) //правильная сумма элементов массива
        {
            if (i >= array.Length)
                return 0;
            int result = array[i] + Sum(array, i + 1);
            return result;
        }

        static int countNum(int num) //сумма цифр числа
        {
            if (num < 10)
            {
                return num;
            }

            return num % 10 + countNum(num / 10);

        }

        static void Main(string[] args)
        {
            // 1) Реализовать вывод массива с помощью рекурсии
            // 2) Найти сумму элементов массива с помощью рекурсии
            // 3) Найти сумму цифр числа с помощью рекурсии (561=12)
            int[] arr = { 43, 65, 3, 4 };
            arrayOutput(arr);
            Console.WriteLine();

            arraySum(arr);
            Console.WriteLine();

            int result = Sum(arr);
            Console.WriteLine(result);
            Console.WriteLine();

            int sum = countNum(88);
            Console.WriteLine(sum);
        }
    }
}
