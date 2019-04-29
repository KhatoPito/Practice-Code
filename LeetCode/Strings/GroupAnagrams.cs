using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KhatoPito.StringPractice
{
  /*
  Given two strings s and t , write a function to determine if t is an anagram of s.

  Example 1:

  Input: s = "anagram", t = "nagaram"
  Output: true
  Example 2:

  Input: s = "rat", t = "car"
  Output: false
  Note:
  You may assume the string contains only lowercase alphabets.

  Follow up:
  What if the inputs contain unicode characters? How would you adapt your solution to such case?
*/
    public static class Anagrams
    {
        public static bool CheckIfStringsAnagrams(string strOne, string strTwo)
        {
            if (strOne.Length != strTwo.Length)
                return false;

            int[] countArray = new int[256];

            for (int i = 0; i < strOne.Length; i++)
            {
                countArray[strOne[i]]++;
                countArray[strTwo[i]]--;
            }

            foreach (var ch in strOne)
            {
                if (countArray[ch] != 0)
                    return false;
            }

            return true;
        }

/*
    Given an array of strings, group anagrams together.

    Example:

    Input: ["eat", "tea", "tan", "ate", "nat", "bat"],
    Output:
    [
      ["ate","eat","tea"],
      ["nat","tan"],
      ["bat"]
    ]
    Note:

    All inputs will be in lowercase.
    The order of your output does not matter.

*/

        public static IList<IList<string>> GroupAnagrams(string[] strs)
        {
            var map = new Dictionary<string, IList<string>>();

            for (int i = 0; i < strs.Length; i++)
            {
                char[] ch = strs[i].ToCharArray();
                Array.Sort(ch);
                var key = new String(ch);

                if (!map.ContainsKey(key))
                {
                    map.Add(key, new List<string>());
                }

                map[key].Add(strs[i]);
            }

            var list = new List<IList<string>>();
            foreach (var kv in map)
            {
                list.Add(kv.Value);
            }

            return map.Values.ToList() as List<IList<string>>;
        }
    }
}
