using System;
using System.Collections.Generic;
using KhatoPito.Heap;
using KhatoPito.Intervals;
using KhatoPito.Math_Problems;
using KhatoPito.Visa_Test;
using KhatoPito.Visa_Test.LCP;
using LCP;

namespace KhatoPito
{
    public class Program
    {

        public static void Main()
        {
            Console.WriteLine(Problem3Test.CommonPrefix(new List<string>{ "aa", "ababaa" }));
            
            //Console.WriteLine(Problem1Test.ModuloKSubsequence(new List<int>{5,1,2,3,4,1}, 3));
            Console.ReadLine();
        }
    }


}
