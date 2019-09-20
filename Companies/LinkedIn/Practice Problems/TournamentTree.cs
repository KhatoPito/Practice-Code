/** 
* A tournament tree is a binary tree 
* where the parent is the minimum of the two children. 
* Given a tournament tree find the second minimum value in the tree. 
* A node in the tree will always have 2 or 0 children. 
* Also all leaves will have distinct and unique values. 
*         2 
*      /    \ 
*     2      3 
*    / \    /  \    
*   4   2   5   3 
* 
* In this given tree the answer is 3. 
*/


class Node {
  Integer value;
  Node left, right;
  Node(Integer value, Node left, Node right) {
    this.value = value;
    this.left = left;
    this.right = right;
  }
}
class Solution {

    public static Integer secondMin(Node root) {
        if(root.left == null || root.right == null) return Integer.MAX_VALUE;
        int min;
        if(root.left.val == root.val) {
            min = Math.min(root.right.val, secondMin(root.left));
        } else {
            min = Math.min(root.left.val, secondMin(root.right));
        }
        
        return min;
    }  
 
}




//  *************************************
/*

Basically, you are comparing all the winners except the first winner. That is why you need to go down it's direction and compare with the other members who haven't faced each other in the process.
Time complexity: O(log(N)) where N is the number of players.
Space complexity: O(log(N)) depth of the recusive stack

*/


