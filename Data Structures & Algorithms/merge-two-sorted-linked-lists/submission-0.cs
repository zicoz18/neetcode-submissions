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
    public ListNode MergeTwoLists(ListNode list1, ListNode list2) {
        ListNode head1 = list1;
        ListNode head2 = list2;
        ListNode returningHead = null;
        ListNode currentNode = null;
        if (head1 == null) return list2;
        if (head2 == null) return list1;
        if (head1.val > head2.val) {
            returningHead = head2;
            head2 = head2.next;
        } else {
            returningHead = head1;
            head1 = head1.next;
        }
        returningHead.next = null;
        currentNode = returningHead;
        returningHead = currentNode;

        PrintList(returningHead);
        PrintList(head1);
        PrintList(head2);
        while (head1 != null || head2 != null) {
            if (head1 != null && head2 != null) {
                if (head1.val < head2.val) {
                    currentNode.next = head1;
                    head1 = head1.next;
                } else {
                    currentNode.next = head2;
                    head2 = head2.next;
                }
            } else if (head1 != null) {
                currentNode.next = head1;
                head1 = head1.next;
            } else {
                currentNode.next = head2;
                head2 = head2.next;
            }
            currentNode = currentNode.next;
            currentNode.next = null;
            PrintList(returningHead);
            PrintList(head1);
            PrintList(head2);
        }
        return returningHead;
    }

    public void PrintList(ListNode node) {
        Console.WriteLine("Current LinkedList");
        string listOutput = "List: ";
        while (node != null) {
            listOutput = listOutput + ", " + node.val;
            node = node.next;
        }
        Console.WriteLine(listOutput);
    }
}