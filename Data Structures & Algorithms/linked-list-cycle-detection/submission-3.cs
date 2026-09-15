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
    public bool HasCycle(ListNode head) {
        if (head == null || head.next == null) return false;
        ListNode fastNode = head.next;
        ListNode slowNode = head;
        while (fastNode != null && fastNode.next != null && fastNode.next.next != null) {
            if (slowNode == fastNode ) return true; 
            slowNode = slowNode.next;
            fastNode = fastNode.next.next;
        }
        return false;
    }
}
