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
    public TreeNode BuildTree(int[] preorder, int[] inorder) {
        if (preorder.Length == 0) return null;
        int rootValue = preorder[0];
        TreeNode root = new TreeNode(rootValue, null, null);
        int rootIndex = Array.IndexOf(inorder, rootValue);
        root.left = BuildTree(preorder.Skip(1).Take(rootIndex).ToArray(), inorder.Take(rootIndex).ToArray());
        root.right = BuildTree(preorder.Skip(rootIndex + 1).ToArray(), inorder.Skip(rootIndex + 1).ToArray());
        return root;
    }
}
