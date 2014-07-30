using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sample_Code
{

	/// <summary>
	/// {1,3,3,5,6,6,6,6,9}
	///  verify if a binary tree is a bst
	/// </summary>
	class samplePracticeVerifyBST
	{

		public class Tree
		{
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


			#region isValidBST
			public Boolean isValid(Node root)
			{
				return isValidBST(root, Int32.MinValue,
					 Int32.MaxValue);
			}

			private Boolean isValidBST(Node node, int MIN, int MAX)
			{
				if (node == null)
					return true;

				if (node.data > MIN
					&& node.data < MAX
					&& isValidBST(node.left, MIN, node.data)
					&& isValidBST(node.right, node.data, MAX))
					return true;
				else
					return false;
			}
			#endregion isValidBST

	            #region isBST
	            private static bool isBST(Node node)
	            {
	                Node prev = null;
	
	                // traverse the tree in inorder fashion and keep track of prev node
	                if (node != null)
	                {
	                    if (!isBST(node.left))
	                        return false;
	
	                    if (prev != null && prev.data >= node.data)
	                        return false;
	
	                    prev = node;
	
	                   return isBST(node.right);                                   
	                }
	
	                return true;
	            }
	            #endregion isBST



			static void Main(string[] args)
			{
				Tree treeObj = new Tree();

				Node nodeObj = new Node(25);
				AddNode(nodeObj, new Node(16));
				AddNode(nodeObj, new Node(20));
				AddNode(nodeObj, new Node(15));
				AddNode(nodeObj, new Node(30));
				AddNode(nodeObj, new Node(36));


				if (treeObj.isValid(nodeObj))
				{
					Console.WriteLine("Tree is BST");
				}
				else
				{
					Console.WriteLine("Tree is not BST");
				}

				//Console.WriteLine("");
				Console.ReadLine();
			}

		}
	}

}
