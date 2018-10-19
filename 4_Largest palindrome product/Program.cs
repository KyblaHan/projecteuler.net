using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
A palindromic number reads the same both ways. The largest palindrome made from the product of two 2-digit numbers is 9009 = 91 × 99.
Find the largest palindrome made from the product of two 3-digit numbers.
 */

namespace _4_Largest_palindrome_product
{
    class Program
    {
        static void Main(string[] args)
        {
            int tmp = 0;
            for (int a = 100; a <= 999; a++)
            {
                for (int b = 100; b <= 999; b++)
                {
                    int s = a * b;
                    if (IsPalindromic(s))
                    {
                        if (s > tmp)
                            tmp = s;
                    }
                }
            }

            Console.WriteLine(tmp);
        }

        static bool IsPalindromic(int s)
        {
            string str = Convert.ToString(s);
            int start = 0;
            int end = str.Length - 1;
            bool res = false;

            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] == str[str.Length - i - 1])
                {
                    start++;
                    end--;
                    res = true;
                }
                else
                {
                    res = false;
                    break;
                }
            }



            return res;
        }
    }
}
