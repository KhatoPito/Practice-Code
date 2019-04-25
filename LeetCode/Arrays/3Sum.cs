using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KhatoPito.ArrayPractice
{
 /*
         *Given an array nums of n integers, are there elements a, b, c in nums such that a + b + c = 0? Find all unique triplets in the array which gives the sum of zero.

        Note:

        The solution set must not contain duplicate triplets.

        Example:

        Given array nums = [-1, 0, 1, 2, -1, -4],

        A solution set is:
        [
          [-1, 0, 1],
          [-1, -1, 2]
        ]
     *
     *
 */

    public static class FindThreeSum
    {

        public static IList<IList<int>> ThreeSum(int[] nums)
        {
            var result = new List<IList<int>>();
            var hashSet = new HashSet<string>();

            if (nums == null || nums.Length == 0)
                return new List<IList<int>>();

             Array.Sort(nums);

             for (int i = 0; i < nums.Length - 2; i++)
             {
                 int start = i + 1;
                 int end = nums.Length - 1;
                 int val = nums[i];

                while (start < end)
                {
                    var list = new List<int>();
                     if (val + nums[start] + nums[end] == 0)
                     {
                         String str = val + ":" + nums[start] + ":" + nums[end];

                         if (!hashSet.Contains(str))
                         {
                            list.Add(val);
                            list.Add(nums[start]);
                            list.Add(nums[end]);
                            result.Add(list);

                            hashSet.Add(str);
                         }

                         while (start < end && nums[start] == nums[start+ 1])
                         {
                             ++start;
                         }
                         while (start < end && nums[end] == nums[end - 1])
                         {
                             --end;
                         }

                        start++;
                         end--;
                     }
                     else if (val + nums[start] + nums[end] < 0)
                     {
                         start++;
                     }
                     else
                     {
                         end--;
                     }
                }

            }

            return result;
        }
    }
}
