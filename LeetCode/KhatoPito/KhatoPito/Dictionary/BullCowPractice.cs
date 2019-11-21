using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KhatoPito.Dictionary
{
    public class BullCowPractice
    {
        public static string CountCowBull(string secret, string guess)
        {
            int bulls = 0;
            int cows = 0;
            int[] numbers = new int[10];
            for (int i = 0; i < secret.Length; i++)
            {
                int s = secret[i] - '0';
                int g = guess[i] - '0';
                if (s == g) bulls++;
                else
                {
                    if (numbers[s] < 0) cows++;
                    if (numbers[g] > 0) cows++;
                    numbers[s]++;
                    numbers[g]--;
                }
            }
           var res =  bulls + "A" + cows + "B";

           return res;

        }


    }
}
