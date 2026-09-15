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
    public TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q) {
        List<TreeNode> pathP = new List<TreeNode>();
        FindNodeAndRecordPath(root, p.val, pathP);
        List<TreeNode> pathQ = new List<TreeNode>();
        FindNodeAndRecordPath(root, q.val, pathQ);
        TreeNode latestCommonNode = root;
        int len = Math.Min(pathP.Count, pathQ.Count);
        for (int i = 0; i < len; i++) {
            TreeNode pNode = pathP[i];
            TreeNode qNode = pathQ[i];
            if (pNode.val == qNode.val) latestCommonNode = qNode;
        }
        return latestCommonNode;
    }

    public void FindNodeAndRecordPath(TreeNode node, int valueToFind, List<TreeNode> path) {
        if (node == null) return;
        path.Add(node);
        if (valueToFind > node.val) {
            FindNodeAndRecordPath(node.right, valueToFind, path);
        } else if (valueToFind < node.val) {
            FindNodeAndRecordPath(node.left, valueToFind, path);
        } else {
            return;
        }
    }
}
