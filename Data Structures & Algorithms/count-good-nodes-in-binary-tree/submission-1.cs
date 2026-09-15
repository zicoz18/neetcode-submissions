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
    public int GoodNodes(TreeNode root) {
        // Implemente DFS and pass the max value seen so far to the recursive calls and the good node count and when the node we are processing has a higher value than max seen so far, increment the good node count
        if (root == null) return 0;
        int goodNodeCount = 0;
        int maxValueSeenSoFar = root.val - 1;
        DFS(root, ref goodNodeCount, maxValueSeenSoFar);
        return goodNodeCount;
    }

    public void DFS(TreeNode node, ref int goodNodeCount, int maxValueSeenSoFar) {
        if (node == null) return; 
        int currentVal = node.val;
        int updatedMaxValue = maxValueSeenSoFar;
        if (currentVal >= maxValueSeenSoFar) {
            goodNodeCount++;
            updatedMaxValue = currentVal;
        }
        DFS(node.left, ref goodNodeCount, updatedMaxValue);
        DFS(node.right, ref goodNodeCount, updatedMaxValue);
    }
}
