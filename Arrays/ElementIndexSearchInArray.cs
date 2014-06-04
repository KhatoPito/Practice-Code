using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElementSearchArray
{
    //•	You are given an array with integers between 1 and 1,000,000.
    //One integer is in the array twice. How can you determine which one? Can you think of a way to do it using little extra memory.
    
    class ElementIndexSearchInArray
    {
        static void Main(string[] args)
        {
            int[] array = new int[1000];
            array[999] = 88;

            for (int i = 0; i < 999; i++)
            {
                array[i] = i;
            }

            bool[] flagArray = new bool[1000];


            foreach (var item in array)
            {
                if (flagArray[array[item]] == false)
                {
                    flagArray[array[item]] = true;
                }
                else
                {
                    Console.WriteLine("Repeated mnum" + array[item]);
                }
            }


            Console.ReadLine();

        }
    }
}
