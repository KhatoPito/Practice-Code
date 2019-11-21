/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int x) { val = x; }
 * }
 */

using System.Collections.Generic;

public class Solution
{
    public class TreeNode
    {
          public int val;
         public TreeNode left;
         public TreeNode right;
         public TreeNode(int x) { val = x; }
     }

    public static IList<IList<int>> LevelOrder(TreeNode root)
    {
        if (root == null)
            return null;

        Queue<TreeNode> queue = new Queue<TreeNode>();

        queue.Enqueue(root);

        var list = new List<IList<int>>();
        var parentList = new List<int>();
        while (queue.Count != 0)
        {

            var node = queue.Dequeue();

            if (node != null)
            {
                parentList.Add(node.val);
            }

            if (node.left != null)
            {
                queue.Enqueue(node.left);

            }
            else if (node.right != null)
            {
                queue.Enqueue(node.right);
            }

            parentList.Add(node.val);
        }

        list.Add(parentList);

        return list;
    }
}