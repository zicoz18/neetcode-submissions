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
    public bool IsSubtree(TreeNode root, TreeNode subRoot) {
        bool isSubTree = false;
        DFS(root, subRoot, ref isSubTree, subRoot);
        return isSubTree;
    }

    public bool DFS(TreeNode node, TreeNode subRoot, ref bool isSubTree, TreeNode originalSubRoot) {
        if (isSubTree) return true; // TODO:
        if (node == null && subRoot == null) return true;
        if (node == null && subRoot != null) return false; // TODO: what if it 
        if (node != null && subRoot == null) return false; // TODO: what if it 
        Console.WriteLine("Node: "+ node.val + ", SubNode: " + subRoot.val);
        if (node.val == subRoot.val) {
            // checking if its subtree
            Console.WriteLine("Calling for: "+ node.left + ", and: " + node.right);
            bool isLeftSub = DFS(node.left, subRoot.left, ref isSubTree, originalSubRoot);
            bool isRightSub = DFS(node.right, subRoot.right, ref isSubTree, originalSubRoot);
            Console.WriteLine("IsLeftSame: " + isLeftSub + ", isRightSame: " + isRightSub);
            if (originalSubRoot.val == subRoot.val && isLeftSub && isRightSub) {
                isSubTree = true;
            } else if (originalSubRoot.val == subRoot.val && !(isLeftSub && isRightSub)) {
                isLeftSub = DFS(node.left, subRoot, ref isSubTree, originalSubRoot);
                isRightSub = DFS(node.right, subRoot, ref isSubTree, originalSubRoot);
            }
            return isLeftSub && isRightSub;
        } else {
            DFS(node.left, subRoot, ref isSubTree, originalSubRoot);
            DFS(node.right, subRoot, ref isSubTree, originalSubRoot);
            return false;
        }
    }
}
