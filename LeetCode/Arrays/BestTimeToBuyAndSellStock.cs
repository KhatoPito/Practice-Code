/*
Say you have an array for which the ith element is the price of a given stock on day i.

If you were only permitted to complete at most one transaction (i.e., buy one and sell one share of the stock), design an algorithm to find the maximum profit.

Note that you cannot sell a stock before you buy one.

Example 1:

Input: [7,1,5,3,6,4]
Output: 5
Explanation: Buy on day 2 (price = 1) and sell on day 5 (price = 6), profit = 6-1 = 5.
             Not 7-1 = 6, as selling price needs to be larger than buying price.
Example 2:

Input: [7,6,4,3,1]
Output: 0
Explanation: In this case, no transaction is done, i.e. max profit = 0.
*/



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

    }
}
