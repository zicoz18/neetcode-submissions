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
    public bool IsSameTree(TreeNode p, TreeNode q) {
        // Initial thing that comes to my mind is, converting the trees to some other representation and checking whether these representations are the same
        // For example, convert them to the array representation similar to how heaps work underneath
        // Then, we would check if each element in the array is equal or not
        // In this case, I believe, building the array repsentation would cost O(N) space and time for each tree and then checking the equal would again cost O(N) so the whole thing would be O(N) space and time
        int maxTreeNodeCount = 102;
        int rootIndex = 0;
        int invalidNodeValue = -101;
        List<int> listP = Enumerable.Repeat(invalidNodeValue, maxTreeNodeCount).ToList();
        List<int> listQ = Enumerable.Repeat(invalidNodeValue, maxTreeNodeCount).ToList();
        ConvertToList(p, rootIndex, listP);
        ConvertToList(q, rootIndex, listQ);
        if (listP.Count != listQ.Count) return false;
        int len = listP.Count;
        for (int i = 0; i < len; i++) {
            if (listP[i] != listQ[i]) return false; 
        } 
        return true;
    }

    public void ConvertToList(TreeNode node, int nodeIndex, List<int> list) {
        if (node == null) return;
        list[nodeIndex] = node.val;
        ConvertToList(node.left, nodeIndex * 2 + 1, list);
        ConvertToList(node.right, nodeIndex * 2 + 2, list);
    }
}
