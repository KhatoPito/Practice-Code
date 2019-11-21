using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KhatoPito.StringPractice
{
    public static class LongestPalindromicSubsequence
    {
        /*
        Given a sequence, find the length of the longest palindromic subsequence in it.
       
       // Every single character is a palindrome of length 1
       L(i, i) = 1 for all indexes i in given sequence

       // IF first and last characters are not same
       If (X[i] != X[j])  L(i, j) =  max{L(i + 1, j),L(i, j - 1)} 

       // If there are only 2 characters and both are same
       Else if (j == i + 1) L(i, j) = 2  

       // If there are more than two characters, and first and last 
       // characters are same
       Else L(i, j) =  L(i + 1, j - 1) + 2 


*/
        //Dynamic Programming Solution
        // Recomputations of same subproblems can be avoided by constructing a temporary array L[][] in bottom up manner.
        //  Recursive Solution - Overlapping Subproblems

        public static int LongestPalindromeSubseq(string s)
        {
            int n = s.Length;

            // Create a table to store results of subproblems 
            int[,] LPS = new int[n,n];

            for (int i = n - 1; i >= 0; i--)
            {
                // Strings of length 1 are palindrome of lentgh 1
                LPS[i, i] = 1;

                for (int j = i+1; j < n; j++)
                {
                    if (s[i] == s[j])
                    {
                        LPS[i, j] = LPS[i + 1, j - 1] + 2;
                    }
                    else
                    {
                        LPS[i, j] = Math.Max(LPS[i + 1, j], LPS[i, j - 1]);
                    }
                }
            }

            return LPS[0,n-1];
        }
    }
}
