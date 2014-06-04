
/* Suppose we are given an array of n integers representing stock prices on a single day.
  We want to find a pair (buyDay, sellDay), with buyDay ≤ sellDay, 
  such that if we bought the stock on buyDay and sold it on sellDay, we would maximize our profit.
 */

using System;

namespace MaxProfitSharePrice
{
    class MaxProfitSharePriceArray
    {
        private static int findMax(int a, int b)
        {
            return a > b ? a : b;
        }

        private static void GetMaxProfit(int[] sharePrices)
        {
            int minSharePrice = sharePrices[0], maxSharePrice = 0, MaxProft = 0;
            int shareBuyValue = sharePrices[0], shareSellValue = sharePrices[0];

            for (int i = 0; i < sharePrices.Length; i++)
            {
                if (sharePrices[i] < minSharePrice )
                {
                    minSharePrice = sharePrices[i];
                    // if we update the min value of share, we need to reset the Max value as 
                    // we can only do this transaction sequence. We need to buy first and then only we can sell.
                    maxSharePrice = 0; 
                }
                else 
                {
                    maxSharePrice = sharePrices[i];
                }

                // We are checking if max and min share value of stock are going to
                // give us better profit then the previously stored one, then store those share values.
                if (MaxProft < (maxSharePrice - minSharePrice))
                {
                    shareBuyValue = minSharePrice;
                    shareSellValue = maxSharePrice;
                }

                MaxProft = findMax(MaxProft, maxSharePrice - minSharePrice);
            }

            Console.WriteLine("Buy stock at ${0} and sell at ${1}, maximum profit can be earned ${2}.", shareBuyValue, shareSellValue, MaxProft);
        }

        static void Main(string[] args)
        {
           int[] sampleArray = new int[] { 1, 3, 4, 1, 1, 2, 11 };
           GetMaxProfit(sampleArray);
            Console.ReadLine();
        }
    }
}
