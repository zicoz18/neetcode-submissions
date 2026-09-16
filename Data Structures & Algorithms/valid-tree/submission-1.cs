public class Solution {
    public class Node {
        public int value;
        public List<Node> homies;

        public Node(int _value) {
            value = _value;
            homies = new List<Node>();
        }
    }

    public bool ValidTree(int nodeCount, int[][] edges) {
        // My first reaction is that, the requirement for a given graph to be a treee is that all connections connect between two different levels.
        // So, no node in the same level can be connected
        // One question here, can a node be connected not with directly upper level but maybe a higher level? 
        // Well, I guess that by definition cant happen as its level is defined as its connected node's level + 1 (based on the direction it could be said to be level - 1)
        //
        // Wait, in the 2nd example, technically all the connections are in between different levels right? like 1 <-> 2 <-> 3 and 3 <-> 1 no connections on the same level yet it creates a problem
        // Maybe I am mistaking the definition of tree in that sense
        // Okay yeah, by definition I guess there has to be a single parent (no need for a parent for the root) for the nodes of a tree rather than multiple
        // Lets assume that I am able to find the root, when performing a DFS, there should be no cycle, I guess. Is that a good definition?
        // Okay, that seems to make sense. Then, how can I find the root? or maybe an even better question, do I even need to find the root? cant I just start from any node?
        // Yeap, I believe I can start from any node and if I detect a cycle I will return false, otherwise true
        // This makes sense. Now, since I am more comfortable with adjencency list representation of graphs, let me convert the edge representation to adjecency list and perform DFS to detect a cycle
        ////
        // Okay submitted above yet based on the failed test on submission, looks like there could be like seperated graphs, so multiple graphs and in that case thats not a tree, which makes sense
        // So, now, I gotta hold like an array to mark nodes as visited and at the end of the DFS, on top of the cycle detection, I gotta make sure that all the nodes are visited

        Node[] nodes = new Node[nodeCount];
        for (int i = 0; i < nodeCount; i++) {
            nodes[i] = new Node(i);
        }

        for (int i = 0; i < edges.Length; i++) {
            int[] edge = edges[i];
            Node node0 = nodes[edge[0]];
            Node node1 = nodes[edge[1]];
            node0.homies.Add(node1);
            node1.homies.Add(node0);
        }

        Node nodeToDFS = nodes[0];

        bool hasFoundCycle = false;
        int visitedCounter = 0;
        DFS(nodeToDFS, ref hasFoundCycle, ref visitedCounter, new HashSet<int>(), -1);
        if (visitedCounter != nodeCount) return false;
        return !hasFoundCycle;
    }

    public void DFS(Node node, ref bool hasFoundCycle, ref int visitedCounter, HashSet<int> visitedSet, int prevNodeValue) {
        if (node == null) return;
        if (hasFoundCycle) return;
        bool hasAddedToSet = visitedSet.Add(node.value);
        if (!hasAddedToSet) {
            hasFoundCycle = true;
            return;
        }
        visitedCounter++;
        foreach (Node homie in node.homies) {
            if (homie.value == prevNodeValue) continue; // Do not go back to the node you have just came from
            DFS(homie, ref hasFoundCycle, ref visitedCounter, visitedSet, node.value);
        }
        visitedSet.Remove(node.value);
    }
}
