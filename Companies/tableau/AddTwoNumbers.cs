/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int x) { val = x; }
 * }
 */
public class Solution {
        
        public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
        {                               
            ListNode tempNode = null, prev = null, node = null;
            int carry = 0;
            int resultSum = 0;

            while (l1 != null || l2 != null)
            {
                int sum = (l1 !=null ? l1.val : 0)  + ( l2 != null ?  l2.val : 0) + carry;
                carry = sum / 10;
                resultSum = sum % 10;

                node = new ListNode(resultSum);

                if (tempNode == null)
                {
                    tempNode = node;
                }
                else
                {
                    prev.next = node;                   
                }

                prev = node;

                if(l1 != null) l1 = l1.next;
                if(l2 != null) l2 = l2.next;

                resultSum = 0;
            }

            if (carry > 0)
            {
                node.next = new ListNode(carry);
            }



            return tempNode;
        }
}
