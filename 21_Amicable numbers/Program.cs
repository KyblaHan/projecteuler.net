using System;
/*
 * Let d(n) be defined as the sum of proper divisors of n (numbers less than n which divide evenly into n).
   If d(a) = b and d(b) = a, where a ≠ b, then a and b are an amicable pair and each of a and b are called amicable numbers.
   
   For example, the proper divisors of 220 are 1, 2, 4, 5, 10, 11, 20, 22, 44, 55 and 110; therefore d(220) = 284. The proper divisors of 284 are 1, 2, 4, 71 and 142; so d(284) = 220.
   
   Evaluate the sum of all the amicable numbers under 10000.
 */
namespace _21_Amicable_numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int summ = 0;
            for (int i = 0; i < 10000; i++)
            {
                if (IsAmicable(i))
                {
                    summ += i;
                }
            }
           Console.WriteLine(summ);
        }

        private static bool IsAmicable(int a)
        {
            int b = SumAmicable(a);
            if (SumAmicable(b) == a && a!=b)
                return true;
            return false;
        }

        static int SumAmicable(int input)
        {
            int output = 0;

            for (int i = 1; i < input/2+1; i++)
            {

                if (input % i == 0)
                    output += i;
            }

            return output;
        }
    }
}
