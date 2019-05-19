using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace KhatoPito.StringPractice
{
    public static class LSolution {
        public static string MostCommonWords(string paragraph, string[] banned)
        {
            Regex rgx = new Regex("[^a-zA-Z0-9 -]+");
            paragraph = rgx.Replace(paragraph, " ").ToLower();

            string[] words = paragraph.Split(' ');
            var map = new Dictionary<string, int>();


            foreach (var word in words)
            {
                if (!map.ContainsKey(word) && !string.IsNullOrEmpty(word))
                {
                    map.Add(word, 1);
                }
                else if (!string.IsNullOrEmpty(word))
                {
                    map[word] += 1;
                }
            }

            foreach (var par in map.OrderByDescending(a => a.Value))
            {
                if (!banned.Contains(par.Key))
                {
                    return par.Key;
                }
            }


            return null;

        }
    }

}
