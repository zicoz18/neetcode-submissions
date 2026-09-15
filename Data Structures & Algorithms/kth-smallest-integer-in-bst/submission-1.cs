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
        List<int> resultArray = new List<int>();
        DFSInOrder(root, resultArray);
        return resultArray[k -1];
    }

    public void DFSInOrder(TreeNode node, List<int> list) {
        if (node == null) return;
        DFSInOrder(node.left, list);
        list.Add(node.val);
        DFSInOrder(node.right, list);
    }
}
