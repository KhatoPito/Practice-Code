using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace KhatoPito.Visa_Test
{
    public static class Problem2Test
    {
        public static int getMaxOccurrences(string s, int minLength, int maxLength, int maxUnique)
        {
            if (string.IsNullOrEmpty(s))
                return 0;

            var list = FindAllSubString(s);
            var dict = new Dictionary<string,int>();

            foreach (var substring in list)
            {
                if (substring.Length >= minLength 
                    && substring.Length <= maxLength
                         && GetAllUniqueChars(substring) <= maxUnique)
                {
                    if (!dict.ContainsKey(substring))
                    {
                        dict.Add(substring, 1);
                    }
                    else
                    {
                        dict[substring] += 1;
                    }
                }
            }

            int maxOccur = 0;

            foreach (var item in dict)
            {
                if (item.Value > maxOccur)
                {
                    maxOccur = item.Value;
                }
            }


            return maxOccur;

        }

        public static List<string> FindAllSubString(string s)
        {
            var stringList = new List<string>();
            for (int i = 0; i < s.Length; i++)
            for (int j = i; j < s.Length; j++)
                stringList.Add(s.Substring(i, j - i + 1));

            return stringList;
        }

        public static int GetAllUniqueChars(string substring)
        {
           var result = substring.Distinct().Count();
           return result;
        }

    }
}
