/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int x) { val = x; }
 * }
 */
public class Solution {
    public ListNode RemoveElements(ListNode head, int val) {
        
        if(head == null) return null;
        
        while(head != null &&  head.val == val)
           head = head.next;
        
        ListNode node = head;
        var prevNode = new ListNode(-1);
        prevNode.next = node;
        
        while(node != null)
        {           
            if(node.val == val)
            {
                prevNode.next = node.next;
                node = node.next;
            }
            else
            {
                prevNode = prevNode.next;
                node = node.next;
                
            }            
        }
        
        return head;
    }
}
