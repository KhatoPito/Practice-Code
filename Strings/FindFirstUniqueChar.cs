using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindFirstUniqueChar
{
    //•	Find the first non-repeating character in a string:("AAAAAAAAAAABCA" -> B ) 
    
    // NOTE - Update - instead of traversing the entire string again, we can keep track of the index of character
   /* Think of the case when a string has miilions of characters - maintaing index for the first occurance along with the
    count will perfrom much better 
    
    The first part of the algorithm runs through the string
    to construct the count array (in O(n) time). This is reasonable. But the second part about running through the string again
    just to find the first non-repeater is not good in practice. In real situations, your string is expected to be much larger than 
    your alphabet. Take DNA sequences for example: they could be millions of letters long with an alphabet of just 4 letters. 
    What happens if the non-repeater is at the end of the string? Then we would have to scan for a long time (again).
    We can augment the count array by storing not just counts but also the index of the
    st time you encountered the character e.g. (3, 26) for ‘a’ meaning that ‘a’ got counted 3 times and the first time 
    it was seen is at position 26. So when it comes to finding the first non-repeater, we just have to scan the count array, 
    instead of the string. Thanks to Ben for suggesting this approach.
    
    http://www.geeksforgeeks.org/given-a-string-find-its-first-non-repeating-character/
*/
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
