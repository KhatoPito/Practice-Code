using System;

namespace Sample_Recursion_MergeSort
{
	/// <summary>
	/// A class to operate MergeSort using recursion
	/// </summary>
	class SamplePractice_MergeSort
	{
		public class MergeSort
		{
			#region OperateMergeSort
			
			private static int[] MergedArray = new int[10];

			private static void OperateMergeSort(int []Array, int start, int end)
			{
				if(end > start)
				{
					int middle = start + (end-start) / 2;
					OperateMergeSort(Array, start, middle);
					OperateMergeSort(Array, middle+1, end);
					Merge(Array, start, middle+1, end);
				}

			}

			private static void Merge(int[] Array, int start, int middle, int end)
			{
				int left = start, pos = start, left_end = (middle - 1);

				while (left <= left_end && middle <= end)
				{
					MergedArray[pos++] = (Array[left] <= Array[middle]) ? Array[left++] : Array[middle++];
				}

				while (left <= left_end)
					MergedArray[pos++] = Array[left++];

				while (middle <= end)
					MergedArray[pos++] = Array[middle++];

				int num_elements = (end - start + 1);

				for (int i = 0; i < num_elements; i++)
				{
					Array[end] = MergedArray[end];
					end--;
				}
			}
			#endregion OperateMergeSort

			#region Main
			static void Main(string[] args)
			{
				int[] Array = new int[] { 1, 33, 2, 76, 11, 23, 3 };
				Console.WriteLine("The Un-Sorted Array ");

				foreach (var value in Array)
					Console.Write(value + " ");

				Console.WriteLine("\r\n");

				OperateMergeSort(Array, 0, Array.Length-1);
				Console.WriteLine("The Sorted Array ");

				foreach (var value in Array)
					Console.Write(value + " ");

				Console.ReadLine();
			}
			#endregion Main
		}
	}
}
