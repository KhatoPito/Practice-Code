using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleStack
{


    public class Node<T>
    {
        public Node<T> next;
        public T data;
        public Node(T data) { this.data = data; }
    }

    class SampleStack<T>
    {
        public Node<T> top;

        public void Pop()
        {
            PrintStack();

            Node<T> tnode = null;

            if (top != null)
            {
                tnode = top;
                top = top.next;
            }

            if (tnode != null)
            {
                Console.WriteLine("{0} is removed from the Stack. ", tnode.data);
            }
            else
            {
                Console.WriteLine("No value removed from the Stack. ");
            }
        }

        public void Push(Node<T> node)
        {

            if (this.top == null)
            {
                top = node;
            }
            else
            {
                node.next = top;
                top = node;
            }
        }

        public void PrintStack()
        {
            if (this.top != null)
            {
                Node<T> tNode = this.top;

                while (tNode != null)
                {
                    Console.Write("{0} - ", tNode.data);
                    tNode = tNode.next;
                }

                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("Stack is Empty");
            }
        }
    }


    class SampleMain
    {
        static void Main(string[] args)
        {
            SampleStack<int> obj = new SampleStack<int>();

            obj.Push(new Node<int>(1));

            obj.Push(new Node<int>(2));
            obj.Pop();
            obj.Push(new Node<int>(3));
            obj.Push(new Node<int>(4));
            obj.Push(new Node<int>(5));
            obj.Pop();

            obj.PrintStack();

            Console.ReadLine();
        }
    }
}
