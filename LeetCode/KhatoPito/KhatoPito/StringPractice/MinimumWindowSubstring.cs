using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KhatoPito.StringPractice
{
    public static class MinimumWindowSubstring
    {
        public static string MinWindow(string s, string t)
        {
            if (string.IsNullOrEmpty(s) || string.IsNullOrEmpty(t))
                return string.Empty;

            //two pointers, one point to tail and one  head
            int start = 0; int end = 0;

            int head = -1;
            int window = int.MaxValue; // the length of substring
            int counter = t.Length; //  counter to check whether the substring is valid
            int[] arr = new int[256];

             /* initialize the array here */ 
            foreach (var ch in t)
                arr[ch]++;


            while (end < s.Length)
            {
                char rc = s[end++];
                if (arr[rc] > 0)
                {
                    counter--; 
                    // {  /* modify counter here */ }
                    // once all char are found counter will become 0
                    
                }

                // reduce it from 1 to 0 and if no match from 0 to -1
                arr[rc]--;

                while (counter == 0)
                {
                    // /* update window here if finding minimum*/
                    if (end - start < window)
                    {
                        head = start;
                        window = end - start;
                    }

                    //increase left/start pointer to make it invalid/valid again
                    char lc = s[start++];

                    // if char found then increase the counter again
                    // as we are moving forward by loosing found char from string
                    // once counter is > 0 - it will get kicked out of current while loop
                    if (arr[lc] == 0)
                        counter++;

                    // increase it back to original 
                    arr[lc]++;
                }
            }

            return head == -1 ? string.Empty : s.Substring(head,  window);

        }

    }
}
