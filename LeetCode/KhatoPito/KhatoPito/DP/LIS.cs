using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KhatoPito.DP
{
    public static class LIS
    {
        public static int LengthOfLIS(int[] nums)
        {
            List<int> list = new List<int>();

            // for each num in nums
            foreach (var num in nums)
            {
                // if(list.size()==0) add num to list
                // if num > last element in list - add num to list
                if (list.Count == 0 || num > list[list.Count - 1])
                    list.Add(num);
                //  if list[i-1] < num <= tails[i], update tails[i]
                // for example, 7-8-10 and num 10 - in that case replace 10 with 9
                else
                {
                    int i = 0;
                    int j = list.Count -1;

                    while (i < j)
                    {
                        int mid = (i + j) / 2;
                        if (list[mid] < num)
                            i = mid + 1;
                        else
                            j = mid;
                    }

                    list[j] = num;                        
                }
            }

            return list.Count;

        }

    }
}
