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
    public void ReorderList(ListNode head) {
        ListNode current = head;
        if (current == null) return;
        while(current != GetPrevTail(current)) {
            ListNode tailPrev = GetPrevTail(current);
            ListNode tail = tailPrev.next;
            tail.next = current.next;
            current.next = tail;
            tailPrev.next= null;
            current = current.next.next;
        }
    }

    public ListNode GetPrevTail(ListNode node) {
        while (node != null && node.next != null && node.next.next != null) {
            node = node.next;
        }
        return node;
    }

}
