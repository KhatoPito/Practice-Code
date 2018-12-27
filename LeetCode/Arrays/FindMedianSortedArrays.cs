using System;
using System.Collections.Generic;
/*
There are two sorted arrays nums1 and nums2 of size m and n respectively.

Find the median of the two sorted arrays. The overall run time complexity should be O(log (m+n)).

You may assume nums1 and nums2 cannot be both empty.

Example 1:

nums1 = [1, 3]
nums2 = [2]

The median is 2.0
Example 2:

nums1 = [1, 2]
nums2 = [3, 4]

The median is (2 + 3)/2 = 2.5
*/

namespace KhatoPito
{
    class FindMedianSortedArrays
    {
        static void Main(string[] args)
        {
            Solution sol = new Solution();
            Console.WriteLine(sol.FindMedianSortedArrays(new int[]{ -5,3,6,12,15 }, new int[] {-12,-10,-6,-3,4,10 }));
            Console.ReadLine();
        }
    }

    public class Solution
    {
        public double FindMedianSortedArrays(int[] nums1, int[] nums2)
        {
            int len1 = nums1.Length;
            int len2 = nums2.Length;
            int totalLength = len1 + len2;
            int[] result = new int[totalLength];
            double median = 0.0d;

            int i=0, j=0, k=0;

            while (i < len1 && j < len2)
            {
                result[k++] = nums2[j] < nums1[i] ? nums2[j++] : nums1[i++];
            }

            while (i < len1)
            {
                result[k++] = nums1[i++];
            }

            while (j < len2)
            {
                result[k++] = nums2[j++];
            }


            if (totalLength % 2 == 0)
            {
                // num is even
                var index = (totalLength / 2) - 1;
                var no1 = result[index];
                var no2 = result[index + 1];
                median = (double)(no1 + no2) / 2;
            }
            else
            {
                // num is odd
                var index = (totalLength)/2;
                median = result[index];
            }

            return median;
        }
    }
}


