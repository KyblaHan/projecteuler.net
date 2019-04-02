using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _36_Double_base_palindromes
{
    class Program
    {
        static void Main(string[] args)
        {
            int summ = 0;
            for (int i = 0; i < 1000000; i++)
            {
                if (IsPalindromic(Convert.ToString(i)))
                    if (IsPalindromic(Convert.ToString(i, 2)))
                    {
                        summ += i;
                        Console.WriteLine(i);
                    }
            }
            Console.WriteLine(summ);
        }
        static bool IsPalindromic(string input)
        {

            int start = 0;
            int end = input.Length - 1;
            bool res = false;

            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == input[input.Length - i - 1])
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
