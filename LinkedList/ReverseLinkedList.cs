using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReverseLinkedList
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

    public sealed class ReverseLinkedList<T>
    {
        #region Private members
        private Node<T> _head;
        private Node<T> last;
        #endregion Private members

        #region Properties
        internal Node<T> Head
        {
            get { return _head; }
            set { _head = value; }
        }

        internal Node<T> Last
        {
            get { return last; }
            set { last = value; }
        }
        #endregion Properties

        #region Helper Methods
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
                    Console.Write(node.data + " -> ");
                    node = node.next;
                }

                Console.WriteLine("NULL");
            }
        }
        #endregion Helper Methods

        internal Node<T> ReverseListWithoutRecursion(Node<T> currentNode)
        {
            Node<T> prevNode = null;
            Node<T> tempNode;

            while (currentNode != null)
            {
                tempNode = currentNode.next;
                currentNode.next = prevNode;
                prevNode = currentNode;
                currentNode = tempNode;
            }

            _head = prevNode;

            return _head;
        }

        internal Node<T> ReverseListWithRecursion(Node<T> currentNode)
        {
            if (currentNode.next == null)
                return currentNode;
            else
            {
                Node<T> nextNode = ReverseListWithRecursion(currentNode.next);
                Node<T> tNode = currentNode.next;
                currentNode.next = null;
                tNode.next = currentNode;

                return nextNode;
            }
        }

        /// <remarks>
        /// Example:
        /// Inputs:  1->2->3->4->5->NULL and k = 3 
        /// Output:  3->2->1->4->5->NULL.
        /// </remarks>
        internal Node<T> Reverse_K_Node_List_WithoutRecursion(Node<T> currentNode, int NumOfNodes)
        {
            Node<T> prevNode = null;
            Node<T> nextNode = currentNode.next;
            Node<T> tailNode = null;
            int count = 0;

            while (currentNode != null && count < NumOfNodes)
            {
                nextNode = currentNode.next;
                currentNode.next = prevNode;
                prevNode = currentNode;

                if (count == 0)
                    tailNode = currentNode;

                currentNode = nextNode;
                count++;
            }

            if (tailNode != null)
                tailNode.next = nextNode;

            _head = prevNode;
            return _head;
        }

        ///<remarks>
        ///  * Reverse a Linked List in groups of given size
        ///  * Reverse k nodes in linked list
        ///  * Example:
        ///  *  Inputs:  1->2->3->4->5->6->7->8->NULL and k = 3 
        ///  *  Output:  3->2->1->6->5->4->8->7->NULL. 
        ///</remarks>
        internal Node<T> Reverse_GroupsOfGivenSize_K_Nodes(Node<T> headNode, int NumOfNodes)
        {

            Node<T> prevNode = null;
            Node<T> nextNode = null;
            Node<T> currentNode = headNode;
            int k = 0;

            while (currentNode != null && k < NumOfNodes)
            {
                nextNode = currentNode.next;
                currentNode.next = prevNode;
                prevNode = currentNode;
                currentNode = nextNode;
                k++;
            }


            if (nextNode != null)
            {
                headNode.next = Reverse_GroupsOfGivenSize_K_Nodes(nextNode, NumOfNodes);
            }

            return prevNode;
        }
    }

    class SimpleMain
    {
        static void Main(string[] args)
        {
            ReverseLinkedList<int> list = new ReverseLinkedList<int>();

            list.AddNode(new Node<int>(1));
            list.AddNode(new Node<int>(2));
            list.AddNode(new Node<int>(3));
            list.AddNode(new Node<int>(4));
            list.AddNode(new Node<int>(5));
            list.AddNode(new Node<int>(6));

            list.PrintList(list.Head);

            //Node<int> obj = list.ReverseListWithoutRecursion(list.Head);
            //Node<int> obj = list.ReverseListWithRecursion(list.Head);
            Node<int> obj = list.Reverse_GroupsOfGivenSize_K_Nodes(list.Head, 3);

            list.PrintList(obj);
            Console.Read();
        }
    }
}
