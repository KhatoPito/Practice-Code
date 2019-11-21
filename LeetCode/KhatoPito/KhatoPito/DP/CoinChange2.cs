using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KhatoPito.DP
{
    public static class CoinChange2Test
    {
        static Dictionary<int, int> dict = new Dictionary<int, int>();
        public static int CoinChange2(int amount, int[] coins )
        {
            int count = 0;
            if (amount < 0 || coins == null || coins.Length == 0) return 0;
            if (amount == 0) return 1;

            if (dict.ContainsKey(amount))
                return dict[amount];

            foreach (var coin in coins)
            {
                Console.WriteLine("Coin is : " + coin + "amount is : " + amount);
                count = CoinChange2(amount - coin, coins);
                count++;   
            }

            dict.Add(amount, count);
            return count;
        }
    }
}
