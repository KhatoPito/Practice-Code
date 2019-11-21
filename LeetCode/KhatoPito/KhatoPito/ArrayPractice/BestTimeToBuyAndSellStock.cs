using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KhatoPito.ArrayPractice
{
    public static class BestTimeToBuyAndSellStock
    {
        public static int MaxProfit(int[] prices)
        {
            if (prices == null || prices.Length == 0)
                return 0;

            int maxProfit = 0; 
            int buyPrice = prices[0];
            int sellPrice = prices[0];


            for (int i = 0; i < prices.Length; i++)
            {
                if (prices[i] < 0)
                    continue;

                if (maxProfit < prices[i] - buyPrice)
                {
                    maxProfit = prices[i] - buyPrice;
                    sellPrice = prices[i];
                }
                else if (prices[i] < buyPrice)
                {
                    buyPrice = prices[i];
                }
            }

            //Console.WriteLine("Buy Price is " + buyPrice + " and Sell Price is " + sellPrice);
            return maxProfit;

        }

        public static int[] ProductExceptSelf(int[] nums)
        {
            int[] result = new int[nums.Length];

            int[] t1 = new int[nums.Length];
            int[] t2 = new int[nums.Length];

            t1[0] = 1;
            t2[nums.Length - 1] = 1;

            //scan from left to right
            for (int i = 0; i < nums.Length - 1; i++)
            {
                t1[i + 1] = nums[i] * t1[i];
            }

            //scan from right to left
            for (int i = nums.Length - 1; i > 0; i--)
            {
                t2[i - 1] = t2[i] * nums[i];
            }

            //multiply
            for (int i = 0; i < nums.Length; i++)
            {
                result[i] = t1[i] * t2[i];
            }

            return result;
        }

        public static int MaxProduct(int[] nums)
        {
            int[] max = new int[nums.Length];
            int[] min = new int[nums.Length];

            max[0] = min[0] = nums[0];
            int result = nums[0];

            for (int i = 1; i < nums.Length; i++)
            {
                if (nums[i] > 0)
                {
                    max[i] = Max(nums[i], max[i - 1] * nums[i]);
                    min[i] = Min(nums[i], min[i - 1] * nums[i]);
                }
                else
                {
                    max[i] = Max(nums[i], min[i - 1] * nums[i]);
                    min[i] = Min(nums[i], max[i - 1] * nums[i]);
                }

                result = Max(result, max[i]);
            }

            return result;
        }

        public static int Max(int a, int b)
        {
            return a > b ? a : b;
        }

        public static int Min(int a, int b)
        {
            return a < b ? a : b;
        }

    }
}
