using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
  Given an integer array with all positive numbers and no duplicates, find the number of possible combinations that add up to a positive integer target.

  Example:

  nums = [1, 2, 3]
  target = 4

  The possible combination ways are:
  (1, 1, 1, 1)
  (1, 1, 2)
  (1, 2, 1)
  (1, 3)
  (2, 1, 1)
  (2, 2)
  (3, 1)

  Note that different sequences are counted as different combinations.

  Therefore the output is 7.


  Follow up:
  What if negative numbers are allowed in the given array?
  How does it change the problem?
  What limitation we need to add to the question to allow negative numbers?

*/
namespace KhatoPito.DP
{

    public static class CombinationSum4Test
    {
        static Dictionary<int, int> dict = new Dictionary<int, int>();
        public static int CombinationSum4(int[] nums, int target)
        {
            int count = 0;
            if (nums == null || nums.Length == 0 || target < 0) return 0;
            if (target == 0) return 1;

            if (dict.ContainsKey(target))
                return dict[target];

            foreach (var num in nums)
                count += CombinationSum4(nums, target - num);

            dict.Add(target, count);
            return count;
        }
    }
}
