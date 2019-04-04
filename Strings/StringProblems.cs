using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringProblems
{
    class StringProblems
    {
        // Determine if a string has all unique characters.
        private static bool HasUniqueChar(string SampleString)
        {
            char[] strArray = SampleString.ToCharArray();
            int length = strArray.Length;
            bool[] flag = new bool[256]; // by default they are all false

            for (int i = 0; i < length - 1; i++)
            {
                if (!flag[strArray[i]])
                {
                    flag[strArray[i]] = true;
                }
                else
                {
                    return false;
                }
            }

            return true;
        }

        // Reverse a string in place.
        private static string ReverseStringInPlace(string SampleString)
        {
            char[] strArray = SampleString.ToCharArray();
            int length = strArray.Length -1;

            for (int i = 0; i < (strArray.Length) / 2; i++)
            {
                strArray[i] ^= strArray[length];
                strArray[length] ^= strArray[i];
                strArray[i] ^= strArray[length--];
            }

            return new String(strArray);
        }

        // Remove duplicates in a string in place.
        private static string RemoveDupInPlaceFromString(string SampleString)
        {
	        char[] strArray = SampleString.ToLower().ToCharArray();
	        int length = strArray.Length;
	        bool[] flag = new bool[256]; // by default they are all false
	        int count = 0;

            for (int i = 0; i < length - 1; i++)
	        {
		        if(flag[strArray[i]] == false)
		        {
                    flag[strArray[i]] = true;
			        strArray[count++] = strArray[i];
		        }
	        }

            return new string(strArray).Remove(count);
        }


        // Write a method to decide if two strings are anagrams or not.
        private static bool CheckIfStringsAnagrams(string strOne, string strTwo)
        {
            if (strOne.Length != strTwo.Length)
                return false;

            char[] strArray1 = strOne.ToCharArray();
            char[] strArray2 = strTwo.ToCharArray();
            int len = strArray1.Length;
            int[] countArray = new int[256];

            for (int i = 0; i < len; i++)
            {
                countArray[strArray1[i]]++;
                countArray[strArray2[i]]--;
            }

            for (int i = 0; i < len; i++)
            {
                if (countArray[strArray1[i]] != 0)
                    return false;
            }
            
            return true;
        }

        static void Main(string[] args)
        {
            //Console.WriteLine("HasUniqueChar(AFFRDD WWQQ) : " + HasUniqueChar("AFFRDD WWQQ"));
            //Console.WriteLine("HasUniqueChar(Bharat) : " + HasUniqueChar("Bharat"));
            //Console.WriteLine("ReverseStringInPlace(Bharat) : " + ReverseStringInPlace("Bharat"));
            //Console.WriteLine("RemoveDupInPlaceFromString(Bharatttttt) : " + RemoveDupInPlaceFromString("Bharatttttt"));

            Console.WriteLine("CheckIfStringsAnagrams(Bharat, Barhat) : " + CheckIfStringsAnagrams("Bharat", "Barhat"));
            

            Console.ReadLine();
        }
    }
}
