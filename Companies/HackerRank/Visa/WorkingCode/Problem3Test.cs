using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KhatoPito.Visa_Test
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    namespace LCP
    {
        class Problem3Test
        {
            
            public static string LongestCommonPrefix(String s1,String s2)
            {
                
                    String small, large;
                    if (s1.Length > s2.Length)
                    { small = s2; large = s1; }
                    else
                    { small = s1; large = s2; }
                    int index = 0;
                    foreach(char c in large.ToCharArray())
                    {
                        if (index == small.Length) break;
                        if (c != small[index]) break;
                        index++;
                    }
                if (index == 0)
                    return null;
                return large.Substring(0, index);
            
            }


            public static List<int> CommonPrefix(List<string> inputs)
            {
                var list = new List<int>();

                foreach (var input in inputs)
                {
                    list.Add(CommonPrefixLength(input));
                }


                return list;
            }

            public static int CommonPrefixLength(string sample)
            {
                var list = new List<int>();

                for (int i = 0; i <= sample.Length - 1; i++)
                {
                    var firstString = sample.Substring(i);
                    var prefix = LongestCommonPrefix(sample,firstString);
                    if (prefix!=null && prefix.Length > 0)
                    {
                        if (sample.Contains(prefix))
                        {
                            list.Add(prefix.Length);
                        }

                    }

                    //if (string.IsNullOrEmpty(secondString))
                    //{
                    //    list.Add(prefix.Length);
                    //}


                }

                return list.Sum();
            }

        }
    }
}
