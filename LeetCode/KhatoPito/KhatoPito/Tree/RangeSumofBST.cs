using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static KhatoPito.Tree.SamplePracTree.Tree;

namespace KhatoPito.Tree
{
    public class RangeSumBSTSolution
    {
        public int RangeSumBST(Node root, int L, int R)
        {

            List<int> list = new List<int>();
            var arr = GetArrayFromBST(root, list);
            int total = 0;

            foreach (var item in list)
            {
                if (item >= L && item <= R)
                {
                    total += item;
                }
            }

            return total;
        }

        List<int> GetArrayFromBST(Node root, List<int> list)
        {
            if (root != null)
            {
                GetArrayFromBST(root.left, list);
                list.Add(root.data);
                GetArrayFromBST(root.right, list);
            }

            return list;
        }

    }
    /// <summary>
    /// {1,3,3,5,6,6,6,6,9}
    ///  verify if a binary tree is a bst
    /// </summary>
        public class SamplePracTree
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

                while (parentNode != null)
                {
                    if (parentNode != null && parentNode.data > node.data)
                    {
                        tempParentNode = parentNode;
                        parentNode = parentNode.left;
                        leftFlag = true;
                        rightFlag = false;
                    }
                    else if (parentNode != null && parentNode.data < node.data)
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
                else if (rightFlag)
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

            #region print all node of a given level
            private void PrintNodeOfGivenLevel(Node node, int height, int level)
            {
                if (height > level || node == null)
                {
                    return;
                }
                else if (level == 0)
                {
                    Console.WriteLine("The root node is:" + node.data);
                }
                else
                {
                    if (height == level - 1)
                    {
                        if (node.left != null)
                        {
                            Console.WriteLine(node.left.data);
                        }

                        if (node.right != null)
                        {
                            Console.WriteLine(node.right.data);
                        }
                    }
                    else
                    {
                        PrintNodeOfGivenLevel(node.left, height + 1, level);
                        PrintNodeOfGivenLevel(node.right, height + 1, level);
                    }
                }
            }
            #endregion print all node of a given level
        }
    }

    }


