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
    public int MaxDepth(TreeNode root) {
        return BreathFirstSearchGetMaxDepth(root);
    }

    public int BreathFirstSearchGetMaxDepth(TreeNode root) {
        Queue<(TreeNode, int)> queue = new Queue<(TreeNode, int)>();
        if (root == null) return 0;
        int currentDepth = 1;
        int maxDepth = currentDepth;
        queue.Enqueue((root, currentDepth));
        while (queue.Count > 0) {
            (TreeNode node, int depth) = queue.Dequeue();
            if (node != null) {
                if (depth > maxDepth) {
                    maxDepth = depth;
                }
                if (node.left != null) {
                    queue.Enqueue((node.left, depth + 1));
                } 
                if (node.right != null) {
                    queue.Enqueue((node.right, depth + 1));
                }
            }
        }
        return maxDepth;
    }
}
