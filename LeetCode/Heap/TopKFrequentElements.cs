using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Using Bucket - O(N) -- Build a array of list to be buckets with length 1 to sort.
// Bucket sort: Time: O(n), Space: O(n)
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


/*
// Heap: Time: O(nlogk), Space: O(k) (This post doesn't limit the size of the heap, so it is still O(nlogn) and O(n), but we can make it to O(nlogk) and O(k))
// use maxHeap. Put entry into maxHeap so we can always poll a number with largest frequency
public class Solution {
    public List<Integer> topKFrequent(int[] nums, int k) {
        Map<Integer, Integer> map = new HashMap<>();
        for(int n: nums){
            map.put(n, map.getOrDefault(n,0)+1);
        }
           
        PriorityQueue<Map.Entry<Integer, Integer>> maxHeap = 
                         new PriorityQueue<>((a,b)->(b.getValue()-a.getValue()));
        for(Map.Entry<Integer,Integer> entry: map.entrySet()){
            maxHeap.add(entry);
        }
        
        List<Integer> res = new ArrayList<>();
        while(res.size()<k){
            Map.Entry<Integer, Integer> entry = maxHeap.poll();
            res.add(entry.getKey());
        }
        return res;
    }
}

*/



