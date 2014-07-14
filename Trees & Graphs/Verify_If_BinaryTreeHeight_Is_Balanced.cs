using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BinaryTreeHeightBalanced
{
    /*
        Consider a height-balancing scheme where following conditions should be checked to determine if a binary tree is balanced.
        An empty tree is height-balanced. A non-empty binary tree T is balanced if:
        1) Left subtree of T is balanced
        2) Right subtree of T is balanced
        3) The difference between heights of left subtree and right subtree is not more than 1.

        To check if a tree is height-balanced, get the height of left and right subtrees.
        Return true if difference between heights is not more than 1 and left and right subtrees are balanced,
        otherwise return false.
    */


    public class VerifyBinaryTreeHeightBalanced
    {
        class TreeNode
        {
            internal TreeNode left;
            internal TreeNode right;
            internal int data;

            public TreeNode(int data)
            {
                this.data = data;
            }
        }


        private static int MaxDepth(TreeNode node)
        {
            if (node == null)
                return 0;

            return 1 + Math.Max(MaxDepth(node.left), MaxDepth(node.right));
        }

        private static int MinDepth(TreeNode node)
        {
            if (node == null)
                return 0;

            return 1 + Math.Min(MinDepth(node.left), MinDepth(node.right));
        }

        /// <summary>
        /// Given a tree data structure, implement a function to check if this tree is balanced or not, 
        /// for the purpose of this problem a balanced tree is a tree such that no two leaf nodes differ
        /// in distance from root by more than one.
        /// </summary>
        public bool CheckIfBinaryTreeHeightIsBalanced(TreeNode root)
        {
            /* If tree is empty then return true */
            if (root == null)
                return true;

            return (MaxDepth(root) - MinDepth(root)) <= 1;
        }
    }
}
