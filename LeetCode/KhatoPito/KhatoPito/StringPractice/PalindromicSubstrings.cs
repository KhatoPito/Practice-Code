using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KhatoPito.StringPractice
{
    public static class PalindromicSubstrings
    {
        private static int count =0;
        private static HashSet<string> set = new HashSet<string>();

        // We can scan to both sides for each character. Time O(n^2), Space O(1)
        public static int PalindromesWithExpand(string s)
        {
            if (string.IsNullOrEmpty(s))
                return 0;

            for (int i = 0; i < s.Length; i++)
            {
                ExtendCount(s, i, i);
                ExtendCount(s, i, i + 1);
            }

            return count;
        }

        public static void ExtendCount(string str, int start, int end)
        {
            while (start >= 0 && end < str.Length && str[start] == str[end])
            {
                start--;
                end++;
                //set.Add(str.Substring(start + 1, end - start - 1));
                count++;
            }
        }
    }
}
