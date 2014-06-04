//-----------------------------------------------------------------------
//Given an array with N integers, write a function which finds subarray consisting of contiguous elements of the array
//such that sum of elements of the subarray is maximized. 
//If array is 1 2 -3 3 -2 4, then last three numbers (3, -2 and 4) are the largest sum subarray, with sum 5.
//-----------------------------------------------------------------------


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleArray
{

    class MaximumSumArray
    {
        // First Approach
        private static void FindMaxSum(int[] array)
        {
            int sum = 0;
            int MaxSum = 0;

            for (int i = 0; i < array.Length; i++)
            {
                sum += array[i];

                if (sum > MaxSum)
                {
                    MaxSum = sum;
                }
                else if (sum < 0)
                {
                    sum = 0;
                }
            }
            Console.WriteLine("Maximum sum is: " + MaxSum);
        }

        // Second Approach - Handles Negative numbers
        private static void FindMaxArray(int[] array)
        {
            int sum = array[0], Maxsum = array[0];

            for (int i = 1; i < array.Length; i++)
            {
                sum = Max(sum + array[i], array[i]);
                Maxsum = Max(sum, Maxsum);               
            }

            Console.WriteLine("Maximum sum is: " + Maxsum);
        }

        private static int Max(int a, int b)
        {
            return a > b ? a : b;
        }


       
        static void Main(string[] args)
        {

            //int[] sampleArray = { 11, 2, -3, 1, 2, -9, 4, -5, 2, 3 };

            int[] sampleArray = { -2, -3, 1, -22, -4, 5, -2, -3 };

            FindMaxArray(sampleArray);
            FindMaxSum(sampleArray);

            Console.ReadLine();
        }
    }
}