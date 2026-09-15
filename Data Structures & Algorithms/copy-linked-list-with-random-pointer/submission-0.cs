/*
// Definition for a Node.
public class Node {
    public int val;
    public Node next;
    public Node random;
    
    public Node(int _val) {
        val = _val;
        next = null;
        random = null;
    }
}
*/

public class Solution {
    public Node copyRandomList(Node head) {
        Node node = head;
        Node copyNode = null;
        Node newHead = null;
        while (node != null) {
            Node newNode = new Node(node.val);
            if (copyNode == null)  {
                copyNode = newNode;
                newHead = newNode;
            } else {
                copyNode.next = newNode;
                copyNode = copyNode.next;
            }
            node = node.next;
        }

        Node iterNode = head;
        Node iterNewNode = newHead;
        while (iterNode != null) {
            Node randomNode = iterNode.random;
            Node iterRandom = head;
            int counter = 0;
            while (iterRandom != randomNode) {
                counter++;
                iterRandom = iterRandom.next;
            }
            Node iterNewRandom = newHead;
            while (counter > 0) {
                counter--;
                iterNewRandom = iterNewRandom.next;
            }
            iterNewNode.random = iterNewRandom;
            // Console.WriteLine("counter: " + counter);
            iterNode = iterNode.next;
            iterNewNode = iterNewNode.next;
        }

        return newHead;


    }
}
