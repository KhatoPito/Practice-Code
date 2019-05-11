using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KhatoPito.Visa_Test
{
    public static class Problem1Test
    {
        public static long ModuloKSubsequence(List<int> nums, int k)
        {
            if (k == 0)
                throw new ArgumentException("k==0");

            List<int[]> result = new List<int[]>();

            if (nums == null || nums.Count == 0)
                return result.Count;

            for (int i = 0; i < nums.Count; i++)
            {
                long sum = 0;
                for (int j = i; j < nums.Count; j++)
                {
                    sum = (sum + nums[j] % k) % k;
                    if (sum == 0)
                    {
                        int size = j - i + 1;
                        int[] sequence = new int[size];
                        Array.Copy(nums.ToArray(), i, sequence.ToArray(), 0, size);

                        if (IsSorted(sequence))
                        {
                            result.Add(sequence);
                        }

                    }
                }
            }
            return result.Count;
        }


        public static bool IsSorted(int[] arr)
        {
            for (int i = 1; i < arr.Length; i++)
            {
                if (arr[i - 1] > arr[i])
                {
                    return false;
                }
            }
            return true;
        }
    }
}
