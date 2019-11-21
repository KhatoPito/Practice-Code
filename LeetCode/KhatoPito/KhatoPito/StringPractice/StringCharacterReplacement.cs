using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KhatoPito.StringPractice
{
    public static class StringCharacterReplacement
    {
        public static int CharacterReplacement(String s, int k)
        {
            int[] charCount = new int[26];

            int left, right, maxCount, maxLen;
            left = right = maxCount = maxLen = 0;

            while (right < s.Length)
            {
                charCount[s[right] - 'A']++;
                maxCount = Math.Max(maxCount, charCount[s[right] - 'A']);
                if (right - left + 1 - maxCount > k) charCount[s[left++] - 'A']--;
                maxLen = Math.Max(right++ - left + 1, maxLen);
            }
            return maxLen;
        }
    }
}
