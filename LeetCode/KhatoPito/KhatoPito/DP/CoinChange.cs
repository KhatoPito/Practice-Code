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
