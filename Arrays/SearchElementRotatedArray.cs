
//find an element in the rotated array efficiently
// The given array is sorted
// Use Binary Search

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchElementRotatedArray
{  
    class SearchElementRotatedArray
    {

        private static int BinarySearchWithRecursion(int[] array, int low, int high, int number)
        {
            int medium = (high + low) / 2;

            if (array[medium] == number)
            {
                return medium;
            }
            else
            {
                if (array[medium] < number)
                {
                   return  BinarySearchWithRecursion(array, medium + 1, high, number);
                }
                else
                {
                   return  BinarySearchWithRecursion(array, low, medium - 1, number);
                }
            }
        }


        private static int BinarySearchWithoutRecursion(int[] array, int low, int high, int number)
        {
            int medium = 0;

            while (low <= high)
            {
                medium = (high + low) / 2;

                if (array[medium] == number)
                    break;
                else if (array[medium] < number)
                {
                    low = medium + 1;
                }
                else
                {
                    high = medium - 1;
                }                   
            }

            return medium;

        }


        private static void BinarySearchWithRecursion_RotatedArray(int[] array, int low, int high, int number)
        {
            int medium = 0;

            while (low <= high)
            {
                medium = (high + low) / 2;

                if (array[medium] == number)
                {
                    Console.WriteLine("The index for the number is: {0}", medium+ 1);
                    break;
                }
                else if (array[medium] < number)
                {
                    BinarySearchWithRecursion_RotatedArray(array, low, medium - 1, number);
                    low = medium + 1;
                }
                else
                {
                    BinarySearchWithRecursion_RotatedArray(array, medium + 1, high, number);
                    high = medium - 1;
                }
            }
        }


        static void Main(string[] args)
        {
            int index = 0;
            //int[] bArray  = {4,6,7,8, 77,655,4777,1,2,3};
            int[] bArray = { 1, 2, 3, 4, 6, 7, 8, 77, 655, 4777 };
            //int[] rArray = { 77, 88, 477, 499, 560, 1, 2, 3, 4, 6, 7, 8 };
            int[] rArray = { 1, 1, 1, 0, 1, 1, 1, 1, 1, 1, 1 };
            //index = BinarySearchWithRecursion(bArray, 0, bArray.Length, 655);
            //index = BinarySearchWithoutRecursion(bArray, 0, bArray.Length, 77);
            
            BinarySearchWithRecursion_RotatedArray(rArray, 0, rArray.Length-1, 0);
            Console.ReadLine();
        }
    }
}