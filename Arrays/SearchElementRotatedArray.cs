
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

/*
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
*/

        int rotated_binary_search(int A[], int N, int key)
        {
          int L = 0;
          int R = N - 1;
         
          while (L <= R) {
            // Avoid overflow, same as M=(L+R)/2
            int M = L + ((R - L) / 2);
            if (A[M] == key) return M;
         
            // the bottom half is sorted
            if (A[L] <= A[M]) {
              if (A[L] <= key && key < A[M])
                R = M - 1;
              else
                L = M + 1;
            }
            // the upper half is sorted
            else {
              if (A[M] < key && key <= A[R])
                L = M + 1;
              else 
                R = M - 1;
            }
          }
          return -1;
        }


        public boolean RrotatedArray_search(int start,int end)
        {
            int mid =(start+end)/2;
            
            if(start>end)
                return  false;
            
            if(data[start]<data[end]){
                return this.normalBinarySearch(start, end);
            }
            else
            {
                //the other part is unsorted.
                return (this.search(start,mid) ||
                this.search(mid+1,end));
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
