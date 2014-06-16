using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace reverseWords
{
    public class ReverseWordsInSentence
    {

        public static void Main(string[] args)
        {
            Console.WriteLine(reverseWords("sample of baroda"));
            Console.ReadLine();
        }

        public static string reverseWords(String s)
        {
            char[] stringChar = s.ToCharArray();
            int length = stringChar.Length, tempIndex = 0;

            Swap(stringChar, 0, length - 1);

            for (int i = 0; i < length; i++)
            {
                if (i == length - 1)
                {
                    Swap(stringChar, tempIndex, i);
                    tempIndex = i + 1;
                }
                else if (stringChar[i] == ' ')
                {
                    Swap(stringChar, tempIndex, i - 1);
                    tempIndex = i + 1;
                }
            }

            return new String(stringChar);
        }

        private static void Swap(char[] p, int startIndex, int endIndex)
        {
            while (startIndex < endIndex)
            {
                p[startIndex] ^= p[endIndex];
                p[endIndex] ^= p[startIndex];
                p[startIndex] ^= p[endIndex];

                startIndex++;
                endIndex--;
            }
        }
    }

}
