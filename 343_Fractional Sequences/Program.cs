using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
 *  For any positive integer k, a finite sequence ai of fractions xi/yi is defined by:
   a1 = 1/k and
   ai = (xi-1+1)/(yi-1-1) reduced to lowest terms for i>1.
   When ai reaches some integer n, the sequence stops. (That is, when yi=1.)
   Define f(k) = n. 
   For example, for k = 20:
   
   1/20 → 2/19 → 3/18 = 1/6 → 2/5 → 3/4 → 4/3 → 5/2 → 6/1 = 6
   
   So f(20) = 6.
   
   Also f(1) = 1, f(2) = 2, f(3) = 1 and Σf(k3) = 118937 for 1 ≤ k ≤ 100.
   
   Find Σf(k3) for 1 ≤ k ≤ 2×106.
 */
namespace _343_Fractional_Sequences
{
    class Program
    {
        static void Main(string[] args)
        {
        }

        static int Func(int k)
        {
            int n;

            for (int i = 0; i < UPPER; i++)
            {
                
            }

            return n;
        }
    }
}
