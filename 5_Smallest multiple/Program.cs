﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
 * 2520 is the smallest number that can be divided by each of the numbers from 1 to 10 without any remainder.

What is the smallest positive number that is evenly divisible by all of the numbers from 1 to 20?
 */
namespace _5_Smallest_multiple
{
    class Program
    {
        static void Main(string[] args)
        {
            int i = 20;
            while (!Check(i))
                i++;
         Console.WriteLine(i);   
        }

        static bool Check(int n)
        {
            bool ch = false;

            for (int i = 1; i <= 20; i++)
            {
                if (n % i == 0)
                    ch = true;
                else
                {
                    ch = false;
                    break;
                }
            }
            return ch;
        }
    }
}
