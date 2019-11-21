using System;

namespace KhatoPito.Sorting_Algos
{
    public class Program
    {
        public static void QuickSort(int[] arr, int left, int right)
        {
            int pivot;
            if (left < right)
            {
                pivot = Partition(arr, left, right);
                QuickSort(arr, left, pivot - 1);
                QuickSort(arr, pivot + 1, right);
            }
        }

        public static int Partition(int[] A, int left, int right)
        {
            int start = left;
            int end = right;
            int pivot = A[left];    // choose first one to pivot

            while (start < end)
            {
                // when left/start is less than pivot increment     
                while (A[start] < pivot)
                    start++;

                // when right/end is greater than pivot decrement      
                while (A[end] > pivot)
                    end--;

                // Swap those two elements
                swap(A, start, end);

            }

            return end; // end/left/j is new pivot 
        }

        public static void swap(int[] A, int left, int right)
        {
            int tmp = A[left];
            A[left] = A[right];
            A[right] = tmp;
        }


        //public static void Main(string[] args)
        //{
        //    int[] A = { 22, 4, 55, 67, -9, 6, 100 };
        //    Console.WriteLine("Array before sort: ");

        //    for (int i = 0; i < A.Length; i++)
        //        Console.Write(A[i] + " ");

        //    Console.WriteLine();

        //    QuickSort(A, 0, A.Length - 1);

        //    Console.WriteLine("Array after sort: ");

        //    for (int i = 0; i < A.Length; i++)
        //        Console.Write(A[i] + " ");
        //}
    }
}
