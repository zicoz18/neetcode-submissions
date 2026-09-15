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
    public ListNode RemoveNthFromEnd(ListNode head, int n) {
        ListNode node = head;
        int len = 0;
        while (node != null) {
            node = node.next;
            len++;
        }
        int removeIndex = len - n;
        ListNode prevNode = null;
        ListNode nodeToRemove = head;
        for (int i = 0; i < removeIndex; i++) {
            prevNode = nodeToRemove;
            nodeToRemove = nodeToRemove.next;
        }
        if (prevNode == null) {
            head = nodeToRemove.next;
        } else {
            prevNode.next = nodeToRemove.next;
        }
        return head;
    }
}
