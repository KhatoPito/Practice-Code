using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


/*
  Given preorder and inorder traversal of a tree, construct the binary tree.

  Note:
  You may assume that duplicates do not exist in the tree.

  For example, given

  preorder = [3,9,20,15,7]
  inorder = [9,3,15,20,7]
  Return the following binary tree:

      3
     / \
    9  20
      /  \
     15   7

*/

namespace KhatoPito.Tree
{
    public static class BuildTreeFromPreAndInOrder
    {
        public class TreeNode
        {
            public int val;
            public TreeNode left;
            public TreeNode right;
            public TreeNode(int x) { val = x; }
        }

        public static TreeNode BuildTree(int[] preorder, int[] inorder)
        {
            if (preorder == null || inorder == null)
                return null;

            int iEnd = inorder.Length - 1;
            int iStart = 0;
            int iPreStartIndex = 0;

            return BuildTreeHelper(iPreStartIndex, iStart, iEnd, preorder, inorder);
        }

        private static TreeNode BuildTreeHelper(int iPreStartIndex, int iStart, int iEnd, int[] preorder, int[] inorder)
        {

            if (iPreStartIndex > preorder.Length - 1 || iStart > iEnd)
                return null;

            TreeNode node = new TreeNode(preorder[iPreStartIndex]);
            int iIndex = 0;

            for (int i = iStart; i <= iEnd; i++)
            {
                if (inorder[i] == node.val)
                {
                    iIndex = i;
                }
            }

            node.left = BuildTreeHelper(iPreStartIndex + 1, iStart , iIndex - 1, preorder, inorder);
            node.right = BuildTreeHelper(iPreStartIndex + iIndex - iStart + 1, iIndex + 1, iEnd, preorder, inorder);

            return node;
        }
    }
}
