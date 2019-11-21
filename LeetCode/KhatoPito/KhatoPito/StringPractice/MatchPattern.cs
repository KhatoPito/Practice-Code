using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KhatoPito.StringPractice
{
    /*
     *Input string: "ab1c"
        Pattern string: "ab\dc"
        Match function output: True
     *
     *Input string: "abc"

Pattern string: "ab\dc"

Match function output: False

 Input string: "ab123cd"

Pattern string: "ab\d+c"

Match function output: True


     *
     *
     */
    public static class MatchPattern
    {
        public static bool Match(char[] input, char[] pattern)
        {
            // Your code here

            int j = 0;
            for (int i = 0; i < input.Length; i++)
            {
                if (!IsThisADigitChar(input[i]) && input[i] == pattern[j])
                {
                    j++;
                }
                else if (pattern[j].ToString() == @"\d" && j+1 < input.Length && pattern[j+1] == '+')
                {
                    while (IsThisADigitChar(input[i])) i++;

                    j++;
                }
                else if(pattern[j].ToString() == @"\d" && IsThisADigitChar(input[i]))
                {
                    j++;
                }
                else
                {
                    return false;
                }
            }


            return true;
        }

        public static bool IsThisADigitChar(char input)
        {

            return (input >= '0') && (input <= '9');

        }
    }
}
