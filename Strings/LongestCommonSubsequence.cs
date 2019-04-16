using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Time Complexity is O(MxN)
// Longest Common Subsequence (LCS) - Table based Dynamic Programming

namespace KhatoPito
{
    public static class LongestCommonSubsequence
    {
        public static int GetLongestCommonSubSequence(string inputText, string pattern)
        {
            int[,] commonSubSequence  = new int[inputText.Length + 1, pattern.Length + 1];

            for (int i = 1; i <= inputText.Length ; i++)
            {
                for (int j = 1; j <= pattern.Length ; j++)
                {
                    if (inputText[i - 1] == pattern[j - 1])
                    {
                        // if (A[i]==B[i])
                        // LCS[i,j] = 1+ LCS[i-1,j-1] 
                        commonSubSequence[i, j] = 1 + commonSubSequence[i - 1, j - 1];
                    }
                    else
                    {
                        // LCS[i,j] =  Max(LCS[i,j-1], LCS[i-1,j]) 
                        commonSubSequence[i,j] = commonSubSequence[i - 1, j] > commonSubSequence[i, j - 1]
                            ? commonSubSequence[i - 1, j]
                            : commonSubSequence[i, j - 1];
                    }

                }

            }

            // LCS will be last entry in the lookup table
            return commonSubSequence[inputText.Length, pattern.Length];
        }
    }
}
