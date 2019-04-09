using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
 

The prime factors of 13195 are 5, 7, 13 and 29.

What is the largest prime factor of the number 600851475143 ?


 */
namespace Largest_prime_factor
{
    class Program
    {
        static void Main(string[] args)
        {
            Int64 num = 600851475143;
            List<int> s = Sieve(7000);
            int tmp=0;

            for (int i = 0; i < s.Count; i++)
            {
                if (s[i] == 1)
                {
                    if (num % i == 0)
                    {
                        num = num / i;
                        tmp = i;
                    }
                }
            }
            Console.WriteLine(tmp);
        }
        static List<int> Sieve(int n)
        {
            List<int> s = new List<int>();
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
            return s;
        }
    }
}
