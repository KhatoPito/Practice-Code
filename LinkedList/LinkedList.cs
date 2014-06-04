using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleLinkedList
{

    public class Node<T>
    {
        internal T data;
        internal Node<T> next;

        public Node() { }

        internal Node(T data)
        {
            this.data = data;
        }
    }

    public sealed class LinkedList<T>
    {

        #region Private members
        private Node<T> _head;
        private Node<T> last;
        #endregion Private members

        #region Properties
        internal Node<T> Head
        {
            get { return _head; }
            set { _head  = value; }
        }

        internal Node<T> Last
        {
            get { return last; }
            set { last = value; }
        }    
        #endregion Properties

        internal void AddNode(Node<T> node)
        {
            Node<T> newNode, tempNode = _head;
            newNode = node;

            if (_head == null)
            {
                _head = newNode;
            }
            else
            {
                if (tempNode != null)
                {
                    while (tempNode.next != null)
                    {
                        tempNode = tempNode.next;
                    }                   
                }
    
                tempNode.next = newNode;
                newNode.next = null;
                last = newNode;
            }        
        }

        internal void PrintList(Node<T> node)
        {
            if (node == null)
            {
                Console.WriteLine("The List is empty.");
            }
            else
            {
                while (node != null)
                {
                    Console.Write(node.data +" -> " );
                    node = node.next;
                }

                Console.WriteLine("null");
            }	
        }

        internal void RemoveNodeAtLocation(int location)
        {
            Node<T> currentNode = _head;

            for (int i = 1; i < location-1; i++)
            {
                if (currentNode == null)
                {
                    Console.WriteLine("The list is empty - can not delete the node.");
                }
                else
                {
                    currentNode = currentNode.next;
                }
            }

            Node<T> tempNode = currentNode.next; 
           currentNode.next = null;
           currentNode.next = tempNode.next;         

        }
    }

    class SimpleMain
    {
        static void Main(string[] args)
        {
            LinkedList<int> list = new LinkedList<int>();

            list.AddNode(new Node<int>(2));
            list.AddNode(new Node<int>(33));
            list.AddNode(new Node<int>(143));
            list.AddNode(new Node<int>(155));

            list.PrintList(list.Head);
            list.RemoveNodeAtLocation(2);
            Console.WriteLine("The list after the removal.");
            list.PrintList(list.Head);

            //Console.WriteLine(list.Head.data);
            //Console.WriteLine(list.Last.data);

            Console.Read();
        }
    }
}
