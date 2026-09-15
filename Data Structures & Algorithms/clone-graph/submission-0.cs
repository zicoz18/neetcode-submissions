// Definition for a Node.
/*
public class Node {
    public int val;
    public IList<Node> neighbors;

    public Node() {
        val = 0;
        neighbors = new List<Node>();
    }

    public Node(int _val) {
        val = _val;
        neighbors = new List<Node>();
    }

    public Node(int _val, List<Node> _neighbors) {
        val = _val;
        neighbors = _neighbors;
    }
}
*/

public class Solution {
    public Node CloneGraph(Node node) {
        Dictionary<Node, Node> oldToNew = new Dictionary<Node, Node>();
        return node != null ? DFS(node, oldToNew) : null;
    }

    public Node DFS(Node node, Dictionary<Node, Node> oldToNew) {
        if (oldToNew.TryGetValue(node, out Node newNode)) {
            return newNode;
        } else {
            Node copyNode = new Node(node.val);
            oldToNew[node] = copyNode;
            foreach (Node neighbor in node.neighbors) {
                copyNode.neighbors.Add(DFS(neighbor, oldToNew));
            }
            return copyNode;
        }
    }

}
