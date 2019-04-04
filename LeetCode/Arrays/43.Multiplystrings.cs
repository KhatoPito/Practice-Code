using System.Linq;
using System.Text;

/*
    Given two non-negative integers num1 and num2 represented as strings, return the product of num1 and num2, also represented as a string.

    Example 1:

    Input: num1 = "2", num2 = "3"
    Output: "6"
    Example 2:

    Input: num1 = "123", num2 = "456"
    Output: "56088"
    Note:

    The length of both num1 and num2 is < 110.
    Both num1 and num2 contain only digits 0-9.
    Both num1 and num2 do not contain any leading zero, except the number 0 itself.
    You must not use any built-in BigInteger library or convert the inputs to integer directly.
*/

namespace KhatoPito
{
    public class Solution43
    {
        public string Multiply(string num1, string num2)
        {
            char[] n1 = num1.ToCharArray().Reverse().ToArray();
            char[] n2 = num2.ToCharArray().Reverse().ToArray();

            int[] d = new int[n1.Length + n2.Length];

            for (int i = 0; i < n1.Length; i++)
            {
                for (int j = 0; j < n2.Length; j++)
                {

                    d[i + j] += (n1[i] - '0') * (n2[j] - '0');
                }
            }

            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < d.Length; i++)
            {
                int mod = d[i] % 10;
                int carry = d[i] / 10;

                if (i + 1 < d.Length)
                {
                    d[i + 1] += carry;                         
                }

                sb.Insert(0, mod);

            }

            while (sb[0] == '0' && sb.Length > 1)
                sb.Remove(0, 1);

            return sb.ToString();
        }
    }
}
