using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KhatoPito.StringPractice
{
    /*
     *
       *Given a string s, find the longest palindromic substring in s. You may assume that the maximum length of s is 1000.

        Example 1:

        Input: "babad"
        Output: "bab"
        Note: "aba" is also a valid answer.
        Example 2:

        Input: "cbbd"
        Output: "bb"
     *
     */

    public static class LongestPalindromicSubstring
    {
        // Time O(n^2) Space O(n^2)
        public static int LongestPalindromeSubstring(string s)
        {
            int n = s.Length;
            string longest = string.Empty;
            int maxLen = 1;
            // Create a table to store results of subproblems 
            bool[,] LPS = new bool[n, n];

            for (int i = n - 1; i >= 0; i--)
            {
                // Strings of length 1 are palindrome of lentgh 1
                LPS[i, i] = true;

                for (int j = i + 1; j < n; j++)
                {
                    if (s[i] == s[j] && (j-i <=2 || LPS[i+1,j-1] ))
                    {
                        LPS[i, j] = true;

                        maxLen = Math.Max(maxLen, j - i + 1);
                        longest = s.Substring(i, maxLen);
                    }
                }
            }

            return maxLen;
        }
    }
}
