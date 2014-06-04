using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleQueue
{


    public class Node<T>
    {
       public Node<T> next;
       public T data;
       public Node(T data) { this.data = data; }    
    }

    class SampleQueue<T>
    {
        public Node<T> first;
        public Node<T> last;

        public void Dequeue()
        {
            Node<T> tnode = null;

            if (first != null)
            {
                tnode = first;
                first = first.next;               
            }

            if (tnode != null)
            {
                Console.WriteLine("{0} is removed from the Queue. ", tnode.data);
            }
            else
            {
                Console.WriteLine("No value removed from the Queue. ");
            }
        }

        public void Enqueue(Node<T> node)
        {

            if (this.first == null)
            {
                first = last = node;
            }
            else
            {
                last.next = node;
                last = node;
            }
        }

        public void PrintQueue()
        {
            if (this.first != null)
            {
                Node<T> tNode = this.first;

                while (tNode != null)
                {
                    Console.Write("{0} - ", tNode.data);
                    tNode = tNode.next;
                }

                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("Queue is Empty");
            }
        }
    }
    
    
    class Program
    {
        static void Main(string[] args)
        {
            SampleQueue<string> obj = new SampleQueue<string>();

            obj.Enqueue(new Node<string>("One"));
            obj.Enqueue(new Node<string>("two"));
            obj.Dequeue();
            obj.Enqueue(new Node<string>("Three"));
            obj.Enqueue(new Node<string>("four"));
            obj.Enqueue(new Node<string>("Five"));
            obj.Dequeue();

            obj.PrintQueue();

            Console.ReadLine();

        }
    }
}
