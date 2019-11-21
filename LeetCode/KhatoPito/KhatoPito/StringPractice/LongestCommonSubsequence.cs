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
        /*
         * i/p for this method is as below
            string inputText = "computer";
            string pattern = "houseboat";
            int[,] commonSubSequence = new int[inputText.Length + 1, pattern.Length + 1];
            Console.WriteLine(LongestCommonSubsequence.GetLongestCommonSubSequenceLength(inputText, pattern, commonSubSequence));
            Console.WriteLine(LongestCommonSubsequence.GetLongestCommonSubSequence(inputText, pattern, 
                                                    inputText.Length, pattern.Length, commonSubSequence));   
         */

        public static int GetLongestCommonSubSequenceLength(string inputText, string pattern, int[,] commonSubSequence)
        {
            //int[,] commonSubSequence  = new int[inputText.Length + 1, pattern.Length + 1];

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

        public static string GetLongestCommonSubSequence(string inputText, string pattern,int i, int j, int[,] commonSubSequence)
        {
            if(i==0 || j == 0)
                return string.Empty;

            if (inputText[i-1] == pattern[j-1])
            {
                return GetLongestCommonSubSequence(inputText, pattern, i - 1, j - 1, commonSubSequence) + inputText[i - 1];
            }
            else
            {
                if (commonSubSequence[i - 1,j] > commonSubSequence[i, j-1])
                {
                    return GetLongestCommonSubSequence(inputText, pattern, i - 1, j, commonSubSequence);
                }
                else
                {
                    return GetLongestCommonSubSequence(inputText, pattern, i, j-1, commonSubSequence);
                }
            }
        }
    }
}
