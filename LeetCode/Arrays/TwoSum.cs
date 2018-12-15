using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * Given an array of integers, return indices of the two numbers such that they add up to a specific target.
  You may assume that each input would have exactly one solution, and you may not use the same element twice.

   Example:
   Given nums = [2, 7, 11, 15], target = 9,
   Because nums[0] + nums[1] = 2 + 7 = 9,
   return [0, 1].

https://leetcode.com/articles/two-sum/
     */

namespace KhatoPito.Arrays
{
    public class TwoSum
    {
        #region CalculateTwoSumSortedArray
        public int[] CalculateTwoSumSortedArray(int[] nums, int target)
        {
            int low = 0;
            int high = nums.Length - 1;
            int[] result = new int[2];


            while (high > low)
            {
                if (nums[low] + nums[high] < target)
                {
                    low = low + 1;
                }
                else if (nums[low] + nums[high] > target)
                {
                    high = high - 1;
                }
                else if (nums[low] + nums[high] == target)
                {
                    result[0] = low;
                    result[1] = high;
                    break;
                }

            }

            return result;
        }
        #endregion CalculateTwoSumSortedArray


        #region CalculateTwoSumUnSortedArray
        public int[] CalculateTwoSumUnSortedArray(int[] nums, int target)
        {
            Dictionary<int, int> map = new Dictionary<int, int>();

            for (int i = 0; i < nums.Length; i++)
            {
                int complement = target - nums[i];

                if (map.ContainsKey(complement))
                {
                    return new int[] { map[complement], i };
                }

                if (!map.ContainsKey(nums[i]))
                     map.Add(nums[i], i);
            }

            throw new ArgumentException("No two sum solution");
        }
        #endregion CalculateTwoSumUnSortedArray

    }
}
