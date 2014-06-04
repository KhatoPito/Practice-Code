using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace SampleLinkedList
{
    #region Node Class
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
    #endregion Node Class

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
            set { _head = value; }
        }

        internal Node<T> Last
        {
            get { return last; }
            set { last = value; }
        }
        #endregion Properties

        #region Basic LinkedList Methods
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

                Console.WriteLine("null");
            }
        }
        #endregion Basic LinkedList Methods

    }

    class SimpleMain
    {
        static void Main(string[] args)
        {
            LinkedList<int> list = new LinkedList<int>();

            list.AddNode(new Node<int>(1));
            list.AddNode(new Node<int>(2));
            list.AddNode(new Node<int>(3));
            list.AddNode(new Node<int>(4));
            list.AddNode(new Node<int>(5));
            list.AddNode(new Node<int>(6));
            list.AddNode(new Node<int>(7));
            list.AddNode(new Node<int>(8));
            list.AddNode(new Node<int>(9));
            list.AddNode(new Node<int>(10));

            list.PrintList(list.Head);


            Console.Read();
        }
    }
}


//namespace sample
//{

//    class MyTest
//    {
//        private static NetworkStream stream;
//        private static TcpClient tcpClient;
//        private static byte[] writeBuffer;
//        private static byte[] readBuffer;

//        static void Main(string[] args)
//        {
//            try
//            {
//                using (tcpClient = new TcpClient())
//                {
//                    Console.WriteLine("Please enter the host IP:");
//                    string host = Console.ReadLine();

//                    Console.WriteLine("Please provide the port to connect on:");
//                    int port = int.Parse(Console.ReadLine());

//                    tcpClient.Connect(host, port);

//                    using (stream = tcpClient.GetStream())
//                    {
//                        Console.WriteLine(ReadOut());

//                        Console.WriteLine("Enter Test Command:");
//                        WriteIn(Console.ReadLine());

//                        Console.WriteLine(ReadOut());


//                    }
//                }
//                //keep it open
//                Console.ReadLine();
//            }
//            catch (SocketException ex)
//            {
//                Console.WriteLine("Socket Error: {0}", ex.Message);
//            }
//            catch (Exception ex)
//            {
//                Console.WriteLine("ERROR: {0}", ex.Message);
//            }
//        }

//        private static void WriteIn(string input)
//        {
//            if (stream.CanWrite)
//            {
//                writeBuffer = System.Text.Encoding.ASCII.GetBytes(input);
//                stream.Write(writeBuffer, 0, writeBuffer.Length);
//            }
//        }


//        private static string ReadOut()
//        {
//            string output = null;

//            if (stream.CanRead)
//            {
//                readBuffer = new byte[tcpClient.ReceiveBufferSize];
//                stream.Read(readBuffer, 0, tcpClient.ReceiveBufferSize);
//                output = ((System.Text.Encoding.ASCII.GetString(readBuffer)).Replace("\0", String.Empty)).Trim();
//            }

//            return output;
//        }


    
//    }


//}