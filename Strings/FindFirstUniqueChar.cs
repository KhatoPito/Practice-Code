using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindFirstUniqueChar
{
    //•	Find the first non-repeating character in a string:("AAAAAAAAAAABCA" -> B ) 

    class FindFirstUniqueChar
    {
        private static char ReturnFirstUniqueChar(string sampleString)
        { 
            char[] samplechar = sampleString.ToCharArray();
            int[] charArray = new int[256];

            for (int i = 0; i < samplechar.Length; i++)
            {
              charArray[samplechar[i]] = charArray[samplechar[i]] + 1;
            }

            for (int i = 0; i < samplechar.Length; i++)
            {
                if (charArray[samplechar[i]] == 1)
                {
                    return samplechar[i];
                }
            }
 
            return '\0';
        }

        static void Main(string[] args)
        {
            Console.WriteLine("The First Unique char in given String is: " + ReturnFirstUniqueChar("AAAAAAAAAAABBC"));
            Console.ReadLine();
        }
    }
}
