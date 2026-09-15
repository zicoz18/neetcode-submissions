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
    public TreeNode InvertTree(TreeNode root) {
        InvertTreeRecursive(root);
        return root;
    }

    public void InvertTreeRecursive(TreeNode node) {
        if (node == null) return;
        TreeNode temp = node.right;
        node.right = node.left;
        node.left = temp;
        InvertTreeRecursive(node.left);
        InvertTreeRecursive(node.right);
    }
}
