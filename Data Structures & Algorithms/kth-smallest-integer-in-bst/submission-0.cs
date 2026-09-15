/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int val=0, TreeNode left=null, TreeNode right=null) {
 *         this.val = val;
 *         this.left = left;
 *         this.right = right;
 *     }
 * }
 */

public class Solution {
    public int KthSmallest(TreeNode root, int k) {
        // There probably is a better solution as this is a BST, but my solution woud work for any tree
        // What I will be doing is, traversing the tree to create an array representation, and using that array to initialize a minHeap and then getting kth min value from the heap
        // This process should be O(klogN) time and O(N) space
        List<int> list = new List<int>();
        DFS(root, list);

        (int, int)[] heapInit = new (int, int)[list.Count];
        for (int i = 0; i < list.Count; i++) {
            heapInit[i] = (list[i], list[i]);
        }

        PriorityQueue<int, int> minHeap = new PriorityQueue<int, int>(heapInit);
        for (int i = 1; i <= k; i++) {
            int latestVal = minHeap.Dequeue();
            if (i == k) return latestVal;
        }
        return -1;
    }

    public void DFS(TreeNode node, List<int> list) {
        if (node == null) return;
        list.Add(node.val);
        DFS(node.left, list);
        DFS(node.right, list);
    }
}

