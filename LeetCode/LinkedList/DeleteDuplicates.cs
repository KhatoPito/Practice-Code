/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int x) { val = x; }
 * }
  Input: 1->2->3->3->4->4->5
  Output: 1->2->5
 */
public class Solution {
    public ListNode DeleteDuplicates(ListNode head) {
               
        ListNode dummy = new ListNode(-100);
        var current = head;
        var prev = dummy;
        
        prev.next = current;

        while(current != null)
        {            
            while(current.next != null && current.val == current.next.val)
            {
                current = current.next;                               
            }
            
            if(prev.next != current)
            {
                prev.next = current.next;
                current = prev.next;
            }          
            else
            {
                prev = prev.next;
                current= current.next;
            }
        }
        
        return dummy.next;
    }
}
