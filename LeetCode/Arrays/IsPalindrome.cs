using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KhatoPito
{
    class Test
    {
        static void Main(string[] args)
        {
            Solution9 sol = new Solution9();
            Console.WriteLine(sol.IsPalindrome(1210));
            Console.ReadLine();
        }
    }

    public class Solution9 {
        public bool IsPalindrome(int x)
        {
            if (x < 0)
                x = -x;
            else if (x == 0)
                return true;

            int result = 0, num = x;
            while (num > 0)
            {
                result = result * 10 + num % 10;
                num = num / 10;
            }
            
            return result == x;
        }
    }

}
