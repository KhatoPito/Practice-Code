using System;

/*

https://stackoverflow.com/questions/380595/multimap-in-net


A Multimap is a general way to associate keys with arbitrarily many values.
Guava’s Multimap framework makes it easy to handle a mapping from keys to multiple values

mapping from unique keys to collections of values.

a -> [1, 2, 4]
b -> [3]
c -> [5] 

*/


namespace MyApp // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MultiMap<string, string> multimap = new MultiMap<string, string>();
            multimap.Add("A", "apple");
            multimap.Add("A", "Avacado");
            multimap.Add("C", "Carrot");
            multimap.Remove("A", "apple");

            foreach (var items in multimap)
            {
                Console.WriteLine("Key {0}", items.Key);
                var set = multimap[items.Key];

                foreach (var val in set)
                {
                    Console.WriteLine("key {0} : has value {1}", items.Key, val);
                }
            }


        }
    }

    public class MultiMap<TKey, TValue> : Dictionary<TKey, HashSet<TValue>>
    {
        public MultiMap() : base()
        {
        }

        public void Add(TKey key, TValue value)
        {
            if (key == null) return;

            HashSet<TValue> container;

            if (this.ContainsKey(key))
            {
                container = this[key];
                container.Add(value);
            }
            else
            {
                container = new HashSet<TValue>();
                container.Add(value);
                this.Add(key, container);
            }

            //if (!this.TryGetValue(key, out container))
            //{
            //    container = new HashSet<TValue>();
            //    base.Add(key, container);
            //}

            //container.Add(value);
        }

        public void Remove(TKey key, TValue value)
        {
            if (key == null) return;

            if (this.ContainsKey(key))
            {
                var container = this[key];
                container.Remove(value);

                if (container.Count <= 0)
                {
                    this.Remove(key);
                }
            }

            //HashSet<TValue> container = null;
            //if (this.TryGetValue(key, out container))
            //{
            //    container.Remove(value);
            //    if (container.Count <= 0)
            //    {
            //        this.Remove(key);
            //    }
            //}
        }

        public HashSet<TValue> GetValues(TKey key, bool returnEmptySet)
        {
            HashSet<TValue> toReturn;

            if (!this.TryGetValue(key, out toReturn) && returnEmptySet)
            {
                toReturn = new HashSet<TValue>();
            }

            return toReturn;                
        }  
    }

}
