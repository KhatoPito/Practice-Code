using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sample_Code
{

    /// <summary>
    /// {1,3,3,5,6,6,6,6,9}
    ///  Find the first & last index of a given number in a sorted arrar allowing duplicates
    /// </summary>
    class BinarySearchFindIndexInSortedArray
    {

        #region BinarySearchFirstOccuranceIndex
        /// <summary>
        /// Binary Search in a sorted array
        /// Find First occurance of a num
        /// </summary>
       public static int BinarySearchFindFirstOccuranceIndex(int[] array, int num)
        {
            int length = array.Length, low = 0;
            int index = -1, high = length;

            while (low <= high)
            {
                int mid = low + (high - low) / 2;

                if (num > array[mid])
                {
                    low = mid + 1;
                }
                else if (num < array[mid])
                {
                    high = mid - 1;
                }
                else if (array[mid] == num)
                {
                    // if the index found, set the high pointer to middle -1 and do Binary search on lower portion of array
                    // to find out the first index of the number
                    index = mid + 1;
                    high = mid - 1;
                }
            }

            return index; 
        }
        #endregion BinarySearchFirstOccuranceIndex

       #region BinarySearchLastOccuranceIndex
       /// <summary>
       /// Binary Search in a sorted array
       /// Find First occurance of a num
       /// </summary>
       public static int BinarySearchFindLastOccuranceIndex(int[] array, int num)
       {
           int length = array.Length, low = 0;
           int index = -1, high = length;

           while (low < high)
           {
               int mid = (low + high )/ 2;

               if (num > array[mid])
               {
                   low = mid + 1;
               }
               else if (num < array[mid])
               {
                   high = mid - 1;
               }
               else if (array[mid] == num)
               {
                   // if the index found, set the low pointer to middle + 1 do Binary Search on upper portion of array
                   // to find out the last index of the found number
                   index = mid + 1;
                   low = mid + 1;
               }
           }

           return index;
       }
       #endregion BinarySearchLastOccuranceIndex


        static void Main(string[] args)
        {

            Console.WriteLine("The Array is: [ 1, 2, 2, 2, 2, 2, 3, 3, 5, 6, 6, 7, 9, 9 ]");
            Console.WriteLine("The First index is: " + BinarySearchFindFirstOccuranceIndex(new int[] { 1, 2, 2, 2, 2, 2, 3, 3, 5, 6, 6, 7, 9, 9 }, 2));

            Console.WriteLine("The Array is: [ 1, 2, 2, 2, 2, 2, 3, 3, 5, 6, 6, 7, 9, 9 ]");
            Console.WriteLine("The Last index is: " + BinarySearchFindLastOccuranceIndex(new int[] { 1, 2, 2, 2, 2, 2, 3, 3, 5, 6, 6, 7, 9, 9 }, 2));
            
            Console.ReadLine();
        }
    }

}