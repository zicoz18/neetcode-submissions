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
    public int DiameterOfBinaryTree(TreeNode root) {
        int maxDiam = 0;
        DepthFirstSearchRecursive(root, ref maxDiam);
        return maxDiam;
    }

    public int DepthFirstSearchRecursive(TreeNode node, ref int maxDiam) {
        if (node == null) return 0;
        int leftHeight = DepthFirstSearchRecursive(node.left, ref maxDiam);
        int rightHeight = DepthFirstSearchRecursive(node.right, ref maxDiam);
        int diam = leftHeight + rightHeight;
        if (diam > maxDiam) maxDiam = diam;
        return Math.Max(leftHeight, rightHeight) + 1;
    }
}
