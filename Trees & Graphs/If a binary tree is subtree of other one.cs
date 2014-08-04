using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


//http://www.geeksforgeeks.org/check-binary-tree-subtree-another-binary-tree-set-2/

namespace Sample_Find_SubTree
{
	/// <summary>
	/// A class where two Trees are used to see if one tree is sub tree of other tree
	/// This is  O(n2) solution for this problem.
	/// Better solu would be to use auxiliary array and store Inorder and PreOrder and check 
	/// is T2 is subarray of T1 or not - That will be O(N)
	/// </summary>
		public class Tree
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

				while (parentNode != null)
				{
					if (parentNode != null && parentNode.data > node.data)
					{
						tempParentNode = parentNode;
						parentNode = parentNode.left;
						leftFlag = true;
						rightFlag = false;
					}

					if (parentNode != null && parentNode.data < node.data)
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


			/*
			You have two very large binary trees: T1, with Millions of node,
			and T2 with hundreds of nodes. 
			Create an algorithm to decide if T2 is a subtree of T1.
			*/
			#region CheckSubTree
			private bool CheckSubTree(Node parent, Node subtree)
			{
				if (parent == null)
					return false;
				else if (subtree == null)
					return true;

				if (IsIdentical(parent, subtree))
					return true;

				return (CheckSubTree(parent.left, subtree) || CheckSubTree(parent.right, subtree));
			}

			private bool IsIdentical(Node parent, Node subtree)
			{
				if (parent == null && subtree == null)
					return true;

				return ((parent.data == subtree.data)
					&& IsIdentical(parent.left, subtree.left)
					&& IsIdentical(parent.right, subtree.right));
			}
			#endregion CheckSubTree

			#region Main
			static void Main(string[] args)
			{
				Tree treeObj = new Tree();

				#region Create Tree
				Node nodeParentObj = new Node(25);
				AddNode(nodeParentObj, new Node(16));
				AddNode(nodeParentObj, new Node(20));
				AddNode(nodeParentObj, new Node(15));
				AddNode(nodeParentObj, new Node(36));
				AddNode(nodeParentObj, new Node(30));
				AddNode(nodeParentObj, new Node(40));
				AddNode(nodeParentObj, new Node(38));
				AddNode(nodeParentObj, new Node(50));

				// create child tree
				Node nodeChildObj = new Node(40);
				AddNode(nodeChildObj, new Node(38));
				AddNode(nodeChildObj, new Node(50));
				#endregion Create Tree

				if(treeObj.CheckSubTree(nodeParentObj, nodeChildObj))
				{
					Console.WriteLine("The provided tree is sub tree.");
				}
				else
				{
					Console.WriteLine("The provided tree is not sub tree.");			
				}

				Console.ReadLine();
			}
			#endregion Main
		}
}
