using System;
/*
Given a 32-bit signed integer, reverse digits of an integer.

    Example 1:

    Input: 123
    Output: 321
    Example 2:

    Input: -123
    Output: -321
    Example 3:

    Input: 120
    Output: 21
    Note:
    Assume we are dealing with an environment which could only store integers within the 32-bit signed integer range: [−231,  231 − 1]. For the purpose of this problem, assume that your function returns 0 when the reversed integer overflows.
   
*/

namespace KhatoPito
{
    class ReverseInteger
    {
        static void Main(string[] args)
        {
            Solution sol = new Solution();
            Console.WriteLine(sol.Reverse(1534236469));
            Console.ReadLine();
        }
    }

    public class Solution
    {
        public int Reverse(int x)
        {
            bool negFlag = false;

            if (x == 0)
                return 0;
            else if (x < 0)
            {
                negFlag = true;
                x = -x;
            }

            int remainder = 0;
            int rev_num = 0;
            int number = x;
            int prev_rev_num = 0;

            while (number > 0)
            {
                remainder = number % 10;
                rev_num = rev_num * 10 + remainder;

                if ((rev_num - remainder) / 10 != prev_rev_num)
                {
                    Console.WriteLine("WARNING OVERFLOWED!!!");
                    return 0;
                }

                prev_rev_num = rev_num;
                number = number / 10;
            }

            return negFlag ? -rev_num : rev_num;
        }
    }
}


