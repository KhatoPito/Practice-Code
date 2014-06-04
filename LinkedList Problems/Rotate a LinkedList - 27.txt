using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sample_Code
{
	/// <summary>
	/// RotateLinkedList with number of specified rotations
	/// </summary>
	class SamplePracticeRotateLinkedList
	{
		public class LinkedList
		{
			private static int _size = 0;

			#region Node Class
			public class Node
			{
				internal Node next;
				internal int data;

				internal Node(int data)
				{
					this.data = data;
				}
			}
			#endregion Node Class

			#region AddNodeAtEnd
			public void AddNodeAtEnd(Node parentNode, Node node)
			{
				if (node == null)
				{
					Console.WriteLine("Node can't be empty");
					return;
				}
				else
				{
					if (parentNode == null)
					{
						parentNode = node;
					}
					else
					{
						Node currentNode = parentNode;
						while (currentNode.next != null)
						{
							currentNode = currentNode.next;
						}

						currentNode.next = node;
					}

					_size++;
				}
			}
			#endregion AddNodeAtEnd

			#region AddNodeAtLocation
			public void AddNodeAtLocation(Node parentNode, Node node, int location)
			{
				int locationCount = 1;

				if (node == null)
				{
					Console.WriteLine("Node can't be empty");
					return;
				}
				else
				{
					if (parentNode == null)
					{
						parentNode = node;
					}
					else
					{
						Node currentNode = parentNode;

						while (currentNode != null)
						{
							if (locationCount == location)
							{
								Node tempNode = currentNode.next;
								currentNode.next = node;
								node.next = tempNode;

								Console.WriteLine("");
								Console.WriteLine("The recently added node is " + node.data + " at location " + location);
								break;
							}
							else
							{
								currentNode = currentNode.next;
							}

							locationCount++;
						}


						if (locationCount > _size)
						{
							Console.WriteLine("");
							Console.WriteLine("The given location is not available in the linked list");
						}
					}

					_size++;
				}
			}
			#endregion AddNodeAtLocation

			#region Print LinkedList
			private void PrintLinkedList(Node parentNode)
			{
				if (parentNode == null)
				{
					Console.WriteLine("The LinkedList is Empty");
				}
				else
				{ 
					Node currentNode = parentNode;
					while (currentNode != null)
					{
						Console.Write(currentNode.data + " ");
						currentNode = currentNode.next;
					}
				}
			}
			#endregion Print LinkedList

			#region FindMiddlePoint
			private void FindMiddlePoint(Node parentNode)
			{
				int counter = 1;
				Node slowPointer = parentNode;
				Node fastPointer = parentNode;


				while (fastPointer.next != null)
				{
					fastPointer = fastPointer.next;

					if (counter % 2 == 0)
					{
						slowPointer = slowPointer.next;
					}

					counter++;
				}

				Console.WriteLine();
				Console.WriteLine("The middle point of the LinkedList is: " + slowPointer.data);
				Console.WriteLine("The last point of the LinkedList is: " + fastPointer.data);

			}
			#endregion FindMiddlePoint

			#region RotateLinkedList
			private Node RotateLinkedList(Node Head, int roation)
			{
				// example 1->2->3->null
				// Head 1
				// Tail 3

				int numRoatation = roation;
				Node Tail =  Head;

				while (Tail.next != null)
				{
					Tail = Tail.next;
				}

				while (numRoatation != 0)
				{
					Tail.next = Head; // 2->3(Tail)->1(Head)->2->3->1
					Tail = Head; // 2->1(Tail)->1(Head)->2->3->1..
					Head = Head.next; // 2(Head)->3->1(Tail)->2->3..
					Tail.next = null; // 2->3->1(Tail)->null
						
					numRoatation--;
				}

				return Head;
			}
			#endregion RotateLinkedList

			#region Main
			static void Main(string[] args)
			{
				LinkedList objLink = new LinkedList();	
				Node objNode = new Node(1);
				objLink.AddNodeAtEnd(objNode, new Node(2));
				objLink.AddNodeAtEnd(objNode, new Node(3));
				objLink.AddNodeAtEnd(objNode, new Node(4));			
				objLink.AddNodeAtEnd(objNode, new Node(5));
				objLink.AddNodeAtEnd(objNode, new Node(6));


				//objLink.PrintLinkedList(objNode);

				// Invoke method to add node at specific location
				//objLink.AddNodeAtLocation(objNode, new Node(101) , 4);
				//objLink.PrintLinkedList(objNode);

				// Invoke method to find the middle point and last point in Linked List
				//objLink.FindMiddlePoint(objNode);

				// Invoke this method to Rotate the Linkedlist with provided number of rotations
				int number_of_Rotation = 1;
				Console.WriteLine("LinkedList after " + number_of_Rotation + " rotations: ");
				Node rotateObj = objLink.RotateLinkedList(objNode, number_of_Rotation);
				objLink.PrintLinkedList(rotateObj);

				Console.ReadLine();
			}
			#endregion Main
		}
	}

}
