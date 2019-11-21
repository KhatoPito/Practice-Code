using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KhatoPito.StringPractice
{
    /*
        *Given a string s, find the longest palindromic substring in s. You may assume that the maximum length of s is 1000.

        Example 1:

        Input: "babad"
        Output: "bab"
        Note: "aba" is also a valid answer.
        Example 2:

        Input: "cbbd"
        Output: "bb"
     *
     *
     */
    // "dabcba"
    public static class LongestPalindromicSubstringWithExpand
    {
        private static int lo = 0, maxLen = 0;

        // We can scan to both sides for each character. Time O(n^2), Space O(1)
        public static string LongestPalindromeWithExpand(string s)
        {
            if (string.IsNullOrEmpty(s))
                return string.Empty;

            if (s.Length < 2)
                return s;

            for (int i = 0; i < s.Length-1; i++)
            {
                ExtendPalindrome(s, i, i); // odd length
                ExtendPalindrome(s, i, i+1); // even length
            }

            return s.Substring(lo, lo + maxLen);
        }

        public static void  ExtendPalindrome(string str, int start, int end)
        {
            while (start >=0 && end < str.Length && str[start] == str[end])
            {
                start--;
                end++;
            }

            if (maxLen < end - start - 1)
            {
                lo = start + 1;
                maxLen = end - start - 1;
            }
        }

    }
}
