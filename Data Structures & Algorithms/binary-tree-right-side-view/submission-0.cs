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
    public List<int> RightSideView(TreeNode root) {
        // You know what, what we can actually do is, BFS. When we are doing BFS, we are actually processing all the level from left to right right? So, we will do the BFS and in addition, we will add the right most value of the list to the results. As BFS is O(N) in time and O(logN) is space this will be our complexity
        if (root == null) return new List<int>();
        List<int> result = new List<int>();
        Queue<TreeNode> queue = new Queue<TreeNode>();
        queue.Enqueue(root);
        while (queue.Count > 0) {
            int levelSize = queue.Count;
            for (int i = 0; i < levelSize; i++) {
                TreeNode node = queue.Dequeue();
                if (node.left != null) queue.Enqueue(node.left);
                if (node.right != null) queue.Enqueue(node.right);
                if (i == levelSize - 1) {
                    result.Add(node.val);
                }
            }
        }
        return result;
    }
}
