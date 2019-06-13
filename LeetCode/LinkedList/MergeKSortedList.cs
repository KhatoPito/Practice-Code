/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int x) { val = x; }
 * }
 */
public class Solution {
    public ListNode MergeKLists(ListNode[] lists) {
        
        ListNode dummyList = null;
        foreach(var item in lists)
        {
            dummyList = MergeLists(dummyList, item);   
        }
        
        return dummyList;
    }
    
    public ListNode MergeLists(ListNode l1, ListNode l2)
    {

  // recursive solution
  /*     if(l1 == null)
            return l2;
        
        if(l2 == null)
            return l1;

        if(l1.val < l2.val)
        {
            l1.next = MergeLists(l1.next, l2);
            return l1;
        }
        else
        {
            l2.next = MergeLists(l1, l2.next);
            return l2;
        }        
    */
    
    // Iterative solution
     ListNode tempNode = new ListNode(-1);
     ListNode head = tempNode;   
        
        while(l1 != null && l2 != null)
        {
            if(l1.val < l2.val)
            {
                tempNode.next = l1;
                l1 = l1.next;
            }
            else
            {
               tempNode.next = l2;
                l2 = l2.next;
            }

            tempNode = tempNode.next;            
        }
        
        while(l1 != null)
        {
            tempNode.next = l1;
            l1 = l1.next;
            tempNode = tempNode.next;
        }
        
        while(l2 != null)
        {
            tempNode.next = l2;
            l2 = l2.next;
            tempNode = tempNode.next;
        }
            
        return head.next;    
    }
}
