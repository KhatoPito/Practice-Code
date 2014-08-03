using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sample_GraphPracticeDFSBFS
{
	/// <summary>
	/// A class where two linked list nodes are added and sum is displayed
	/// </summary>
	class SamplePractice_DFS_BFS
	{
		public class GraphPractice_DFS_BFS
		{
			#region Node Class
			public class Node
			{
				internal Node left;
				internal Node right;
				internal int data;

				internal Node(int data)
				{
					this.data = data;
				}
			}
			#endregion Node Class

			#region AddNode
			static public void AddNode(Node parentNode, Node node)
			{
				Node currentNode = node, tempParentNode = parentNode;
				bool leftFlag = false, rightFlag = false;

				while(parentNode != null )
				{
					if(parentNode!= null && parentNode.data > node.data)
					{
						tempParentNode = parentNode;
						parentNode = parentNode.left;
						leftFlag = true;
						rightFlag = false;
					}

					if(parentNode != null && parentNode.data < node.data)
					{
						tempParentNode = parentNode;
						parentNode = parentNode.right;
						leftFlag = false;
						rightFlag = true;
					}
	
				}

				if (leftFlag)
				{
					tempParentNode.left = node;
				}

				if (rightFlag)
				{
					tempParentNode.right = node;
				}
			}
			#endregion AddNode

			#region BFS_Traverse
			private void BFS_Traverse(Node rootNode)
			{
				Queue<Node> queue = new Queue<Node>();
				queue.Enqueue(rootNode);
				Node tempNode = null;

				Console.WriteLine("Breadth First Traverse is as below ");

				while (queue.Count > 0)
				{
					tempNode = queue.Dequeue();
					Console.Write(tempNode.data + " ");

					if (tempNode.left != null)
					{
						queue.Enqueue(tempNode.left);
					}

					if (tempNode.right != null)
					{
						queue.Enqueue(tempNode.right);
					}

				}

			}
			#endregion BFS_Traverse

			#region DFS_Traverse
			private void DFS_Traverse(Node rootNode)
			{
				Stack<Node> stack = new Stack<Node>();
				stack.Push(rootNode);
				Node tempNode = null;

				Console.WriteLine("Depth First Traverse is as below ");

				while (stack.Count > 0)
				{
					tempNode = stack.Pop();
					Console.Write(tempNode.data + " " );

					if (tempNode.right != null)
					{
						stack.Push(tempNode.right);
					}

					if (tempNode.left != null)
					{
						stack.Push(tempNode.left);
					}
					
				}
			}
			#endregion DFS_Traverse
			
			
			#region Graph_Path_To_Node
			// Keep track of the predecessor nodes. 
			// In the easiest implementation, this is a dictionary, 
			// and usually denoted as π in pseudo-codes:
			private void Graph_Path_To_Node(Node rootNode, Node findNode)
			{
				Dictionary<Node, bool> visited = new Dictionary<Node, bool>();
				Dictionary<Node, Node> π = new Dictionary<Node, Node>();
				
				Queue<Node> worklist = new Queue<Node>();
				
				visited.Add(this, false);
				
				worklist.Enqueue(this);
				
				while (worklist.Count != 0)
				{
				    Node node = worklist.Dequeue();
				
				    foreach (Node neighbor in node.Neighbors)
				    {
				        if (!visited.ContainsKey(neighbor))
				        {
				            visited.Add(neighbor, false);
				            π.Add(neighbor, node);
				            worklist.Enqueue(neighbor);
				        }
				    }
				}
				
			}
			
			
			#endregion Graph_Path_To_Node
			

			#region Main
			static void Main(string[] args)
			{
				GraphPractice_DFS_BFS treeObj = new GraphPractice_DFS_BFS();

				#region Create Tree
				Node nodeObj = new Node(25);
				AddNode(nodeObj, new Node(16));
				AddNode(nodeObj, new Node(20));
				AddNode(nodeObj, new Node(15));
				AddNode(nodeObj, new Node(36));
				AddNode(nodeObj, new Node(30));
				#endregion Create Tree

				treeObj.BFS_Traverse (nodeObj);
				Console.WriteLine("");
				treeObj.DFS_Traverse(nodeObj);


				Console.ReadLine();
			}
			#endregion Main
		}
	}
}
