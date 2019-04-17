using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
    Given two strings ‘X’ and ‘Y’, find the length of the longest common substring.
    Examples :

    Input : X = "GeeksforGeeks", y = "GeeksQuiz"
    Output : 5
    The longest common substring is "Geeks" and is of
    length 5.

    Input : X = "abcdxyz", y = "xyzabcd"
    Output : 4
    The longest common substring is "abcd" and is of
    length 4.

    Input : X = "zxabcdezy", y = "yzabcdezx"
    Output : 6
    The longest common substring is "abcdez" and is of
    length 6.
 */

// Time Complexity is O(MxN)
// Longest Common Substring (LCS) - Table based Dynamic Programming

/* i/p as below
    string inputText = "abcdxyz";
    string pattern = "xyzabcd";
    Console.WriteLine(LongestCommonSubstring.GetLongestCommonSubstringLength(inputText, pattern));
 */


namespace KhatoPito
{
    public static class LongestCommonSubstring
    {
        public static int GetLongestCommonSubstringLength(string inputText, string substring)
        {
            int result = 0;
            int[,] commonSubString = new int[inputText.Length + 1, substring.Length + 1];

            for (int i = 1; i <= inputText.Length; i++)
            {
                for (int j = 1; j <= substring.Length; j++)
                {
                    if (i == 0 || j == 0)
                        commonSubString[i, j] = 0;

                    else if (inputText[i - 1] == substring[j - 1])
                    {
                        commonSubString[i, j] = 1 + commonSubString[i - 1, j - 1];
                        result = Math.Max(result, commonSubString[i, j]);
                    }
                    else
                    {
                        commonSubString[i, j] = 0;
                    }
                }
            }

            return result;
        }
    }
}
