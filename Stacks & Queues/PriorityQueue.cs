using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriorityQueue
{
    public sealed class  PriorityQueue
    {
        private int _sizeDict = 0;
        public SortedDictionary<int, Queue<object>> sortedDict = new SortedDictionary<int, Queue<object>>();

        public bool IsEmpty()
        {
            return (_sizeDict == 0);
        }

        public object Dequeue(int priority)
        {
            if (!IsEmpty())
                _sizeDict--;

            Console.WriteLine("Removed Item is: " + sortedDict[priority].First());                    
            return sortedDict[priority].Dequeue();
        }

        public object Dequeue()
        {
            if (IsEmpty())
                throw new Exception("Please check that priorityQueue is not empty before dequeing");
            else
            {
                foreach (Queue<object> queue in sortedDict.Values)
                {
                    _sizeDict--;

                    Console.WriteLine("Removed Item is: " + queue.First());                    
                    return queue.Dequeue();
                }                
            }

            Debug.Assert(false, "not supposed to reach here. problem with changing total_size");
            return null; // not supposed to reach here.
        }

        public void Enqueue(int priority, object item)
        {
            if (sortedDict.ContainsKey(priority))
            {
                sortedDict[priority].Enqueue(item);
                _sizeDict++;
            }
            else 
            {
                Queue<object> queue = new Queue<object>();
                sortedDict.Add(priority, queue);
                Enqueue(priority, item);
            }
        }

        public void PrintQueue(PriorityQueue queue)
        {

            foreach (KeyValuePair<int, Queue<object>> Qu in queue.sortedDict)
            {
                int priority = Qu.Key;
                Queue<object> tQueue = Qu.Value;

                foreach (object item in tQueue)
                {
                    Console.WriteLine("Item is: {1} with priority {0}", priority, item);                    
                }
            }       
        }  
    }

    class SamplePriorityQueue
    {
        static void Main(string[] args)
        {
            PriorityQueue pQueue = new PriorityQueue();

            pQueue.Enqueue(1, "1st Item");
            pQueue.Enqueue(1, "2nd Item");
            pQueue.Enqueue(3, "3rd Item");
            pQueue.Enqueue(2, "4th Item");
            pQueue.Enqueue(4, "5th Item");

            pQueue.PrintQueue(pQueue);

            pQueue.Dequeue(1);
            pQueue.Dequeue(4);

            pQueue.PrintQueue(pQueue);

            Console.ReadLine();
        }
    }
}
