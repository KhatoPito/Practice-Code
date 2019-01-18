using System;
using System.Collections.Generic;
/*
Given a non-empty array of digits representing a non-negative integer, plus one to the integer.

The digits are stored such that the most significant digit is at the head of the list, and each element in the array contain a single digit.

You may assume the integer does not contain any leading zero, except the number 0 itself.

Example 1:

Input: [1,2,3]
Output: [1,2,4]
Explanation: The array represents the integer 123.
Example 2:

Input: [4,3,2,1]
Output: [4,3,2,2]
Explanation: The array represents the integer 4321.
*/

namespace KhatoPito
{
    class PlusOne
    {
        static void Main(string[] args)
        {
            Solution sol = new Solution();
            Console.WriteLine(sol.PlusOne(new int[]{ 9,9,9,9 }));
            Console.ReadLine();
        }
    }

    public class Solution
    {
        public int[] PlusOne(int[] digits)
        {

            if (digits == null || digits.Length == 0)
                return new int[0];

            int carry = 1;
            int length = digits.Length;
            int []answer = new int[digits.Length + 1];


            for (int i = length - 1; i >= 0; i--)
            {

                int result = digits[i] + carry;

                if (result >= 10)
                {
                    carry = 1;
                }
                else
                {
                    carry = 0;
                }

                digits[i] = result % 10;

            }

            if (carry == 1)
            {
                digits.CopyTo(answer, 1);
                answer[0] = 1;
                return answer;
            }
            else
            {
                return digits;
            }
        }
    }
}


