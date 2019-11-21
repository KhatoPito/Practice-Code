using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
     *Given a string, find the length of the longest substring without repeating characters.

    Example 1:

    Input: "abcabcbb"
    Output: 3 
    Explanation: The answer is "abc", with the length of 3. 
    Example 2:

    Input: "bbbbb"
    Output: 1
    Explanation: The answer is "b", with the length of 1.
    Example 3:

    Input: "pwwkew"
    Output: 3
    Explanation: The answer is "wke", with the length of 3. 
                 Note that the answer must be a substring, "pwke" is a subsequence and not a substring.
 *
 *
 * the basic idea is, keep a hashmap which stores the characters in string as keys and their positions as values,
 * and keep two pointers which define the max substring. move the right pointer to scan through the string ,
 * and meanwhile update the hashmap. If the character is already in the hashmap,
 * then move the left pointer to the right of the same character last found. Note that the two pointers can only move forward.
 */

namespace KhatoPito.StringPractice
{
    public static class LongestUniqueSubString
    {
        public static int FindLongestUniqueSubString(string s)
        {
            int[] map = new int[256];
            int left = 0;
            int max = 0;
            for (int right = 0; right < s.Length; right++)
            {
                while (map[s[right]] != 0) map[s[left++]]--;
                map[s[right]]++;
                max = Math.Max(right - left + 1, max);
            }
            return max;

        }


    }
}
