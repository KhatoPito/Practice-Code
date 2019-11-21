﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
matches
Input: text (string), query (string)
Output: true if you can find a match for query within text, false otherwise
If there are no special characters, most languages have a contains method that will just do this.
One special character: '?' -- if you find '?' in the query string, it signals that the previous character is optional (matches 0 or 1 times).

Examples:
  No question marks:
    matches("hello Coursera", "hello") returns true
    matches("hello Coursera", "course") returns false
    matches("hello Coursera", "o C") returns true
    matches("hello Coursera", "C o") returns false
    matches("hello Coursera", "h C") returns false
  With question marks -- "l?" means "optional l":
    matches("heo Coursera", "hel?o") returns true
    matches("helo Coursera", "hel?o") returns true
    matches("hello Coursera", "hel?o") returns false
  Make sure you understand this case:
    matches("hello Coursera", "hell?lo") returns true
  You can have more than one question mark:
    matches("hello Coursera", "ex?llo Courses?") returns true
*/


namespace KhatoPito
{
    public class StringPatternMatch
    {
        public static bool MatchPattern(string inputText, string pattern)
        {
            int count = 0; int patternIndex = 0;

            for (var i = 0; i < inputText.Length; i++)
            {
                if (patternIndex > pattern.Length)
                    break;

                if (inputText[i] == pattern[patternIndex] ||
                    (inputText[i] != pattern[patternIndex] && pattern[patternIndex + 1] == '?'))
                    count++;

                patternIndex++;
            }

            return pattern.Length == count;
        }
    }
}
