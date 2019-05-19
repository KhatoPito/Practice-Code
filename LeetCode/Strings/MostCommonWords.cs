using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;


    /*
    Given a paragraph and a list of banned words, return the most frequent word that is not in the list of banned words.  It is guaranteed there is at least one word that isn't banned, and that the answer is unique.

    Words in the list of banned words are given in lowercase, and free of punctuation.  Words in the paragraph are not case sensitive.  The answer is in lowercase.



    Example:

    Input: 
    paragraph = "Bob hit a ball, the hit BALL flew far after it was hit."
    banned = ["hit"]
    Output: "ball"
    Explanation: 
    "hit" occurs 3 times, but it is a banned word.
    "ball" occurs twice (and no other word does), so it is the most frequent non-banned word in the paragraph. 
    Note that words in the paragraph are not case sensitive,
    that punctuation is ignored (even if adjacent to words, such as "ball,"), 
    and that "hit" isn't the answer even though it occurs more because it is banned.


    Note:

    1 <= paragraph.length <= 1000.
    0 <= banned.length <= 100.
    1 <= banned[i].length <= 10.
    The answer is unique, and written in lowercase (even if its occurrences in paragraph may have uppercase symbols, and even if it is a proper noun.)
    paragraph only consists of letters, spaces, or the punctuation symbols !?',;.
    There are no hyphens or hyphenated words.
    Words only consist of letters, never apostrophes or other punctuation symbols.

*/
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
