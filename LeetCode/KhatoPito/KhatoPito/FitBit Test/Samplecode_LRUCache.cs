using System;
using System.Collections.Generic;
using System.Linq;

namespace samplecode_LRUCache
{
    public class LRUCache<K, V>
    {
        // Dictionary will give constant time O(1) 
        public Dictionary<K, V> cacheDict;
        // C# implements LinkedList as Doubly LinkedList which will give O(1) for addlast and remove from first
        public LinkedList<K> cacheList;
        public int capacity;
        public int size;

        public LRUCache(int capacity)
        {
            this.capacity = capacity;
            cacheDict = new Dictionary<K, V>();
            cacheList = new LinkedList<K>();
        }

        public V Get(K key)
        {
            // If the item is used - remove the item from the front as it becomes most recently used item
            // Bring it back to the list and add it to Last 
            // so that on front you have least Recently used item in the list
            V value = default(V);

            if (cacheDict.ContainsKey(key))
            {
                value = cacheDict[key];
                cacheList.Remove(key);
                cacheList.AddLast(key);
            }

            return value;

        }

        public void Put(K key, V value)
        {
            // If the item exist in the Dict, just replace its value 
            // Key will be same but value might have changed
            if (cacheDict.ContainsKey(key))
            {
                cacheDict[key] = value;
                cacheList.Remove(key);
                cacheList.AddLast(key);
            }
            else
            {
                // if the cache size if full, remove the least recently used element from the list - cacheList.First()
                // at the same time remove the item from the Dictionary as well
                if (size >= capacity)
                {
                    var k = cacheList.First();
                    cacheList.Remove(k);
                    cacheDict.Remove(k);
                    cacheDict.Add(key, value);
                    cacheList.AddLast(key);
                }
                else
                {
                    // If it is a new item and doesn't exist in the Dictionary
                    // Add that item to the Dictionary and also add that item in the List to keep and maintain the order
                    // The Recently added item goes to the end of the list
                    cacheDict.Add(key, value);
                    cacheList.AddLast(key);
                    size++;
                }
            }
        }
    }

    //class sample
    //{
    //    static void Main(string[] args)
    //    {
    //        LRUCache<string, string> lruCache = new LRUCache<string, string>(3);
    //        lruCache.Put("1", "one"); // 1
    //        lruCache.Put("2", "two"); // 2 1
    //        lruCache.Put("3", "three"); // 3 2 1
    //        lruCache.Put("4", "Four"); // 4 3 2 
    //        lruCache.Get("2"); // 2 4 3
    //        Console.ReadLine();
    //    }
    //}
}
