﻿using System;
using System.Collections.Generic;
/*
Given a string, find the length of the longest substring without repeating characters.

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
*/

namespace KhatoPito
{
    class LengthOfLongestSubstring
    {
        static void Main(string[] args)
        {
            Solution sol = new Solution();
            Console.WriteLine(sol.LengthOfLongestSubstring("abcabcbb"));
            Console.ReadLine();
        }
    }

    public class Solution
    {
        public int LengthOfLongestSubstring(string input)
        {
            if (string.IsNullOrEmpty(input))
                return 0;

            Dictionary<char, int> stringMap = new Dictionary<char, int>();
            int start = 0, result = 1;

            for (int i = 0; i < input.Length; i++)
            {
                if (stringMap.ContainsKey(input[i]))
                {
                    // start point is max of found char index and existing starting point
                    start = Math.Max( start, stringMap[input[i]] + 1);
                    stringMap[input[i]] = i;
                    // once found the character - update the index for the char so that you 
                    // start next interation after that 
                }
                else
                    // if no match - just add to collection
                    stringMap.Add(input[i], i);   

                // final result is max of existing result with compare to new result 
                // i is current index, start is the starting point and +1 because 0 based array index
                result = Math.Max(result, i - start + 1);
            }

            return result;
        }
    }
}


