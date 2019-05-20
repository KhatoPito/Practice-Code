/*
  You are given coins of different denominations and a total amount of money amount. Write a function to compute the fewest number of coins that you need to make up that amount. If that amount of money cannot be made up by any combination of the coins, return -1.

  Example 1:

  Input: coins = [1, 2, 5], amount = 11
  Output: 3 
  Explanation: 11 = 5 + 5 + 1
  Example 2:

  Input: coins = [2], amount = 3
  Output: -1
  Note:
  You may assume that you have an infinite number of each kind of coin.
*/

using System.Collections.Generic;

namespace KhatoPito.DP
{
    public static class CoinChangeTest
    {
        static Dictionary<int, int> dict = new Dictionary<int, int>();
        //static Dictionary<int, List<int>> coinDict = new Dictionary<int, List<int>>();
        public static int CoinChange(int[] coins, int amount)
        {
            dict.Add(0, 0);
            return HelperCoinChange(coins, amount, dict);
        }


        public static int HelperCoinChange(int[] coins, int amount, Dictionary<int, int> dict)
        {
            if (amount < 0) return -1;
            if (amount == 0) return 0;
            if (dict.ContainsKey(amount)) return dict[amount];

            var min = -1;

            foreach (var item in coins)
            {
                var leftAmout = HelperCoinChange(coins, amount - item, dict);
                if (leftAmout < 0) continue;

                leftAmout++;
                min = leftAmout < min || min == -1 ? leftAmout : min;
            }

            dict.Add(amount, min);
            return min;
        }
    }
}
