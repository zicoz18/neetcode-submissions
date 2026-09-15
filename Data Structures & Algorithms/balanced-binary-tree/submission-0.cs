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
    public bool IsBalanced(TreeNode root) {
        bool isBalanced = true;
        DPFRecursiveHeight(root, ref isBalanced);
        return isBalanced; 
    }

    public int DPFRecursiveHeight(TreeNode node, ref bool isBalanced) {
        if (node == null) return 0;
        if (!isBalanced) return -1;
        int leftHeight = DPFRecursiveHeight(node.left, ref isBalanced);
        int rightHeight = DPFRecursiveHeight(node.right, ref isBalanced);
        int currentHeight = Math.Max(leftHeight, rightHeight) + 1;
        int heightDiff = Math.Abs(leftHeight - rightHeight);
        // bool isLeftBalanced = currentHeight == leftHeight + 1;
        // bool isRightBalanced = currentHeight == rightHeight + 1;
        if (heightDiff > 1) {
            isBalanced = false;
        }
        return currentHeight;
    }
}
