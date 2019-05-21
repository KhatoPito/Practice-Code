// need to modify https://www.geeksforgeeks.org/design-a-data-structure-for-lru-cache/
// Instead of List use DoublyLinkedList which gives O(1)

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace samplecode_LRUCache
{
    class LRUCache<K,V>
    {
        int capacity = 0;
        int cacheSize = 0;

        Dictionary<K, V> cacheDict;
        List<K> cacheList;


        public LRUCache(int capacity)
        {
            this.capacity = capacity;
            cacheDict = new Dictionary<K, V>(capacity);
            cacheList = new List<K>();
        }

        public V get(K key)
        {
            V value = default(V);

            // If the item is used
            // Remove the item from the front as it becomes most recently used item
            // Bring it back to the list and add it to Last 
            // so that on front you have least Recently used item in the list
            if (cacheDict.ContainsKey(key))
            {
                value = cacheDict[key];
                cacheList.Remove(key);
                cacheList.Add(key);
            }
            else
            {
                Console.WriteLine("The key doesn't exist!!");
            }

            return value;    
        }

        public void set(K key, V value)
        {
            if ( cacheSize >= capacity)
            {
                // if the cache size if full, remove the least recently used element from the list
                // at the same time remove the item from the Dictionary as well
                K k = cacheList.First();
                cacheDict.Remove(k);
                cacheList.Remove(k);
            }

            if (!cacheDict.ContainsKey(key))
            {
                // If it is a new item and doesn't exist in the Dictionary
                // Add that item to the Dictionary and also add that item in the List to keep and maintain the order
                // The Recently added item goes to the end of the list
                cacheDict.Add(key, value);
                cacheList.Add(key);
                cacheSize++;  
            }
        }
    }

    class sample
    {
        static void Main(string[] args)
        {
            LRUCache<string, string> lruCache = new LRUCache<string, string>(3);

            lruCache.set("1", "one"); // 1
            lruCache.set("2", "two"); // 2 1
            lruCache.set("3", "three"); // 3 2 1
            lruCache.set("4", "Four"); // 4 3 2 

            lruCache.get("2"); // 2 4 3

            Console.ReadLine();
        }
    }
}
