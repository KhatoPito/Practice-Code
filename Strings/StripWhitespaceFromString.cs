using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StripWhitespaceFromString
{
    class StripWhitespaceFromString
    {
        // •	Strip whitespace from a string in-place
        private static string RemoveWhiteSpaceFromString(string sampleString)
        {
            char[] whitespacedArray = sampleString.ToCharArray();
            int i = 0, j = 0;

            foreach (var item in whitespacedArray)
            {
                if (whitespacedArray[j] != ' ')
                {
                    whitespacedArray[i++] = whitespacedArray[j++];
                }
                else
                {
                    j++;
                }
           }

            return new string(whitespacedArray).Remove(i);
        }

        static void Main(string[] args)
        {
            Console.WriteLine(RemoveWhiteSpaceFromString("Him aa layaa "));

            //double myresult = Pow(-2.0, 3);
            //double dotnetResult = Math.Pow(-2, 3);
            //Console.WriteLine("The num is " + Pow(2.0, -5));
            Console.ReadLine();
        }
    }
}
