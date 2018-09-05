using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
    If we list all the natural numbers below 10 that are multiples of 3 or 5, we get 3, 5, 6 and 9. The sum of these multiples is 23.

    Find the sum of all the multiples of 3 or 5 below 1000.

*/
namespace Multiples_of_3_and_5
{
    class Program
    {
        static void Main(string[] args)
        {
            int summ=0;

            for (int i = 1; i < 1000; i++)
                if (i % 3 == 0 || i % 5 == 0)
                    summ += i;
            Console.WriteLine(summ);
        }
    }
}
