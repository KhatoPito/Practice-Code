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

    //public static double Pow(double a, int b)
    //{
    //    double result = 1.0;
    //    bool isAnegative = false;
    //    bool isBnagative = false;


    //    if (a == 0) return 0;
    //    if (b == 0) return 1;

    //    if (a < 0) isAnegative = true;
    //    if (b < 0) isBnagative = true;

    //    double tempB = Math.Abs(b);
    //    double tempA = Math.Abs(a);

    //    while (tempB > 0)
    //    {
    //        result = result * tempA;
    //        tempB = tempB - 1;
    //    }

    //    if (isBnagative)
    //        result = (1 / result);

    //    if (isAnegative && (b%2!=0)) 
    //        result = - result;

    //      return result;
    //}
}
