using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
