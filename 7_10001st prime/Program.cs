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
            List<int> tmp = new List<int>();
            tmp = Sieve(1000000);


            Console.WriteLine(tmp[10001]);
        }
        static List<int> Sieve(int n)
        {
            List<int> s = new List<int>();
            List<int> outList = new List<int>();

            s.Add(0); // 1 - не простое число
            s.Add(0); // 1 - не простое число
            // заполняем решето единицами
            for (int k = 2; k <= n; k++)
                s.Add(1);

            for (int k = 2; k * k <= n; k++)
            {
                // если k - простое (не вычеркнуто)
                if (s[k] == 1)
                {
                    // то вычеркнем кратные k
                    for (int l = k * k; l <= n; l += k)
                    {
                        s[l] = 0;
                    }
                }
            }

            for (int i = 0; i <= n; i++)
            {
                if (s[i] == 1)
                    outList.Add(i);
            }

            return outList;
        }
    }
}
