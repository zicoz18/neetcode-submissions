/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int val=0, ListNode next=null) {
 *         this.val = val;
 *         this.next = next;
 *     }
 * }
 */

public class Solution {
    public ListNode AddTwoNumbers(ListNode l1, ListNode l2) {
        // try creating the result node as we are pasing like when iterating 1 and 4 at the same time, just create the node and put 5 in it (if its above 10, have a remainder an put the mod of 10 to the node)
        ListNode head = new ListNode();
        ListNode node = head;
        int remainder = 0;
        while (!(l1 == null && l2 == null)) {
            int digitSum = 0;
            if (l1 != null) {
                digitSum += l1.val;
                l1 = l1.next;
            }
            if (l2 != null) {
                digitSum += l2.val;
                l2 = l2.next;
            } 
            digitSum += remainder;
            remainder = 0;
            if (digitSum < 10) {
                node.next = new ListNode();
                node.next.val = digitSum;
                node = node.next;
            } else {
                remainder++;
                digitSum = digitSum % 10;
                node.next = new ListNode();
                node.next.val = digitSum;
                node = node.next;
            }
        }
        if (remainder != 0) {
            node.next = new ListNode();
            node.next.val = remainder;
            node = node.next;
        } 
        return head.next;
    }
}
