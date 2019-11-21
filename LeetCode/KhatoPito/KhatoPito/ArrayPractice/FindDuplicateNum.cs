using System;

namespace KhatoPito.ArrayPractice
{
    public static class FindDuplicateNum
    {
        // FastSlowPointer
        public static int FSPFindDuplicate(int[] nums)
        {
            int fast = nums[nums[0]];
            int slow = nums[0];

            while (slow != fast)
            {
                slow = nums[slow];
                fast = nums[nums[fast]];
            }

            fast = 0;
            while (fast != slow)
            {
                fast = nums[fast];
                slow = nums[slow];
            }

            return slow;
        }

        // update index with -No
        public static int FindDuplicate(int[] nums)
        {
            foreach (var num in nums)
            {
                var no = Math.Abs(num);

                if (nums[no] >= 0)
                    nums[no] = -nums[no];
                else
                    return no;                        
            }

            return -1;
        }
    }
}
