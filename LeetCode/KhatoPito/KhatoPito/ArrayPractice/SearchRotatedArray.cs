using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;

namespace KhatoPito.ArrayPractice
{
    /*
        *Suppose an array sorted in ascending order is rotated at some pivot unknown to you beforehand.

        (i.e.,  [0,1,2,4,5,6,7] might become  [4,5,6,7,0,1,2]).

        Find the minimum element.

        You may assume no duplicate exists in the array.

        Example 1:

        Input: [3,4,5,1,2] 
        Output: 1
        Example 2:

        Input: [4,5,6,7,0,1,2]
        Output: 0
        Accepted
     *
     *
     */


    public static class SearchRotatedArray
    {
        public static int FindMin(int[] nums)
        {
            if (nums == null || nums.Length == 0)
                return -1;

            return FindMin(nums, 0, nums.Length - 1);
        }

        public static int FindMin(int[] nums, int start, int end)
        {
            if (start == end)
                return nums[start];

            if (end - start == 1)
                return Math.Min(nums[start], nums[end]);

            int mid = start + end/ 2;

            if (nums[start] < nums[end])
                return nums[start];

            else if (nums[mid] > nums[start])
            {
                return FindMin(nums, mid, end);
            }
            else
            {
                return FindMin(nums, start,mid);
            }
        }

    }
}
