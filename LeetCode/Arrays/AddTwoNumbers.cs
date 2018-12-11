using System;
/*
    You are given two non-empty linked lists representing two non-negative integers. 
    The digits are stored in reverse order and each of their nodes contain a single digit. 
    Add the two numbers and return it as a linked list.

    You may assume the two numbers do not contain any leading zero, except the number 0 itself.

    Example:

    Input: (2 -> 4 -> 3) + (5 -> 6 -> 4)
    Output: 7 -> 0 -> 8
    Explanation: 342 + 465 = 807.     
*/

namespace KhatoPito
{
    class AddTwoNumbers
    {
        static void Main(string[] args)
        {
            ListNode n1 = new ListNode(1);
            n1.next = new ListNode(8);
            //n1.next.next = new ListNode(3);

            ListNode n2 = new ListNode(0);
            //n2.next = new ListNode(6);
            //n2.next.next = new ListNode(4);

            Solution sol = new Solution();

            Console.WriteLine(sol.AddTwoNumbers(n1,n2));
            Console.ReadLine();
        }
    }

    public class ListNode
    {
         public int val;
         public ListNode next;
         public ListNode(int x) { val = x; }
     }

    public class Solution
    {
        public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
        {                               
            ListNode head = null, prev = null, tempNode = null;
            int carry = 0, resultSum = 0;

            while (l1 != null || l2 != null)
            {
                int sum = (l1 !=null ? l1.val : 0)  + ( l2 != null ?  l2.val : 0) + carry;
                carry = sum / 10;
                resultSum = sum % 10;

                tempNode = new ListNode(resultSum);

                if (head == null)
                    head = tempNode;
                else
                    prev.next = tempNode;                   

                prev = tempNode;

                if(l1 != null) l1 = l1.next;
                if(l2 != null) l2 = l2.next;

                resultSum = 0;
            }

            if (carry > 0)
                tempNode.next = new ListNode(carry);

            return head;
        }
    }
}


