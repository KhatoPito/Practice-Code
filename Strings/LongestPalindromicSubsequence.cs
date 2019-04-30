using System;

// https://www.geeksforgeeks.org/?p=19155/
namespace ConsoleApp1
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

    public static class LongestPalindromicSubsequence
    {
        //  Recursive Solution - Overlapping Subproblems
        public static int LPS(char[] seq, int i, int j)
        {
            // Base Case 1: If there is only 1 character 
            if (i == j)
                return 1;

            // Base Case 2: If there are only 2 characters and both are same  
            if (i + 1 == j && seq[i] == seq[j])
                return 2;

            // If the first and last characters match  
            if (seq[i] == seq[j])
                return LPS(seq, i + 1, j - 1) + 2;

            // If the first and last characters do not match 
            return max(LPS(seq, i, j - 1), LPS(seq, i + 1, j));
        }


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


        // A utility function to get max of two integers  
        static int max(int x, int y)
        {
            return (x > y) ? x : y;
        }


        public class Program
        {
            static void Main(string[] args)
            {
                //string text = "BBABCBCAB";
                //Console.WriteLine(LongestPalindromicSubsequence.LPS(text.ToCharArray(), 0, text.Length - 1));

                string seq = "GEEKS FOR GEEKS";
                int n = seq.Length;
                Console.Write("The lnegth of the "
                          + "lps is " + LongestPalindromicSubsequence.lps(seq.ToCharArray()));

                Console.ReadLine();
            }
        }
    }
}
