using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KhatoPito.Heap
{
    public static  class TopKFrequentElements
    {
        public static IList<int> TopKFrequent(int[] nums, int k)
        {
            var list = new List<int>();
            Dictionary<int, int> map = new Dictionary<int, int>();

            foreach (var num in nums)
            {
                if (!map.ContainsKey(num))
                {
                    map.Add(num, 1);
                }
                else
                {
                    map[num] += 1;
                }
            }

            var bucket = new List<int>[nums.Length + 1];

            foreach (var item in map.Keys)
            {
                int freq = map[item];
                if (bucket[freq] == null)
                {
                    bucket[freq] = new List<int>();
                }

                bucket[freq].Add(item);
            }

            var res = new List<int>();

            for (int pos = bucket.Length-1; pos >= 0 && res.Count < k; pos--)
            {
                if (bucket[pos] != null)
                {
                    res.AddRange(bucket[pos]);
                }
            }


            return res;
        }
    }
}
