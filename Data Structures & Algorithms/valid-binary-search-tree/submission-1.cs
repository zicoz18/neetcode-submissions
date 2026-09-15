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
    public bool IsValidBST(TreeNode root) {
        int invalidMinVal = -1000000001;
        int invalidMaxVal = 1000000001;
        int min = invalidMinVal;
        int max = invalidMaxVal;
        return isValidBSTRecursive(root, min, max);
    }

    public bool isValidBSTRecursive(TreeNode node, int min, int max) {
        if (node == null) return true;
        if (!(min < node.val && node.val < max)) return false;
        return isValidBSTRecursive(node.left, min, node.val) && isValidBSTRecursive(node.right, node.val, max);
    }
}
