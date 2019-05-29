/*
  102. Binary Tree Level Order Traversal
  Medium

  1455

  37

  Favorite

  Share
  Given a binary tree, return the level order traversal of its nodes' values. (ie, from left to right, level by level).

  For example:
  Given binary tree [3,9,20,null,null,15,7],
      3
     / \
    9  20
      /  \
     15   7
  return its level order traversal as:
  [
    [3],
    [9,20],
    [15,7]
  ]

*/



public class Solution {
    public IList<IList<int>> LevelOrder(TreeNode root)
    {
        var list = new List<IList<int>>();
                
        if (root == null) return list;

        Queue<TreeNode> queue = new Queue<TreeNode>();
        queue.Enqueue(root);
        
        
        while (queue.Count > 0)
        {
            int currentLevelSize = queue.Count;
            var parentList = new List<int>();
            int index = 0;
            
            while(index < currentLevelSize)
            {
                var tempNode = queue.Peek();
                queue.Dequeue();
                parentList.Add(tempNode.val);
                
                if (tempNode.left != null)
                {
                    queue.Enqueue(tempNode.left);
                }
                
                if (tempNode.right != null)
                {
                    queue.Enqueue(tempNode.right);
                }  
                
                index++;
                
            }
            
            list.Add(parentList);            

        }


        return list;
    }
}
