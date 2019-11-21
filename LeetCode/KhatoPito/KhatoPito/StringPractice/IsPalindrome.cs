using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

/*
     *Given a string, determine if it is a palindrome, considering only alphanumeric characters and ignoring cases.

    Note: For the purpose of this problem, we define empty string as valid palindrome.

    Example 1:

    Input: "A man, a plan, a canal: Panama"
    Output: true
    Example 2:

    Input: "race a car"
    Output: false
 *
 */
namespace KhatoPito.StringPractice
{
    // i/p Console.WriteLine(IsPalindrome.CheckPalindrome("A man, a plan, a canal: Panama"));
    public static class IsPalindrome
    {
        public static bool CheckPalindrome(string s)
        {
            char[] charArray = s.ToLower().ToCharArray();
            int start = 0; int end = s.Length - 1;

            while (start < end)
            {
                if(char.IsLetterOrDigit(charArray[start]) && char.IsLetterOrDigit(charArray[end]))
                {
                    if (charArray[start++] != charArray[end--])
                        return false;
                }
                else
                {
                    if (!char.IsLetterOrDigit(charArray[start]))
                        start++;

                    if (!char.IsLetterOrDigit(charArray[end]))
                        end--;
                }
             }

            return true;
        }

        //bool isPalindrome(string str)
        //{
        //    // Check for palindrome. 
        //    int n = str.size();
        //    for (int i = 0; i < n / 2; i++)
        //        if (str.at(i) != str.at(n - i - 1))
        //            return false;

        //    // palindrome string 
        //    return true;
        //}
    }
}
