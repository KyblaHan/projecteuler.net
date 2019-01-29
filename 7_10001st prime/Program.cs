using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
 By listing the first six prime numbers: 2, 3, 5, 7, 11, and 13, we can see that the 6th prime is 13.

        What is the 10 001st prime number?
 */

namespace _7_10001st_prime
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> Tmp = new List<int>();
            Tmp = sieve(1000000);


            Console.WriteLine(Tmp[10001]);
        }
        static List<int> sieve(int n)
        {
            List<int> S = new List<int>();
            List<int> OutList = new List<int>();

            S.Add(0); // 1 - не простое число
            S.Add(0); // 1 - не простое число
            // заполняем решето единицами
            for (int k = 2; k <= n; k++)
                S.Add(1);

            for (int k = 2; k * k <= n; k++)
            {
                // если k - простое (не вычеркнуто)
                if (S[k] == 1)
                {
                    // то вычеркнем кратные k
                    for (int l = k * k; l <= n; l += k)
                    {
                        S[l] = 0;
                    }
                }
            }

            for (int i = 0; i <= n; i++)
            {
                if (S[i] == 1)
                    OutList.Add(i);
            }

            return OutList;
        }
    }
}
