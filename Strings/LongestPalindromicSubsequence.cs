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
        public static int lps(char[] seq)
        {
            int n = seq.Length;
            // Create a table to store results of subproblems 
            int[,] L = new int[n,n];

            // Strings of length 1 are palindrome of lentgh 1
            for (int i = 0; i < n; i++)
                 L[i,i] = 1;

            // cl is length of substring 
            for (int cl = 2; cl <= n; cl++)
            {
                for (int i = 0 ; i < n-cl+1; i++)
                {
                    int j = cl + i - 1;

                    if (seq[i] == seq[j] && i == 2)
                        L[i, j] = 2;

                    else if (seq[i] == seq[j])
                        L[i, j] = 1 + L[i + 1, j - 1] + 2;

                    else
                        L[i, j] = max(L[i + 1, j], L[i, j - 1]);

                }
            }


            return L[0, n - 1];
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
