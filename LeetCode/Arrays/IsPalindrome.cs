using System;
/*
     Determine whether an integer is a palindrome. An integer is a palindrome when it reads the same backward as forward.

    Example 1:

    Input: 121
    Output: true
    Example 2:

    Input: -121
    Output: false
    Explanation: From left to right, it reads -121. From right to left, it becomes 121-. Therefore it is not a palindrome.
    Example 3:

    Input: 10
    Output: false
    Explanation: Reads 01 from right to left. Therefore it is not a palindrome.
    Follow up:

    Coud you solve it without converting the integer to a string?
*/

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
