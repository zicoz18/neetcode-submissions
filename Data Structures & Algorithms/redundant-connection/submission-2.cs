public class Solution {
    public class Node {
        public int value;
        public List<Node> homies;

        public Node(int _value) {
            value = _value;
            homies = new List<Node>();
        }
    }

    public int[] FindRedundantConnection(int[][] edges) {
        // First thing that comes to my mind is, 
        // Try out removing each edge and DFS that version
        // If that version still visits all the nodes and has no edge, that is a correct edge so return
        // If either one happens, try the next edge

        ////// OR

        // What if, we just do DFS directly and when we detect the cycle, we return the edge that causes it?
        // Well, wouldnt that possible make it not connected? I guess not
        // Like if there is a cycle, removing a single edge, should still make it connected
        // I hope that it makes it non cyclical, I guess if there were multiple cycles, removing a single one would not be enough, but if there is a cycle caused by a single edge, removing a single edge might be good enough
        // Oh, wait given there are multiple possible edges to remove, they do want me to return the one that appears latest in the edges list
        // So, I gotta define the whole cycle? and check each edge?
        // Okay, I will already have visited set type of thing to detect the cycle but now, I will have path variable as a list and whenever I detect a cycle. I will try to find the node's value in the path list and now I will know the cycle path. As a result, from there, I can get all the edges in the cycle and return the one that appears latest
        int nodeCount = edges.Length + 1;
        Node[] nodes = new Node[nodeCount];
        for (int i = 1; i < nodeCount; i++) {
            nodes[i] = new Node(i);
        }

        for (int i = 0; i < edges.Length; i++) {
            int[] edge = edges[i];
            Node node0 = nodes[edge[0]];
            Node node1 = nodes[edge[1]];
            node0.homies.Add(node1);
            node1.homies.Add(node0);
        }

        bool hasFoundCycle = false;
        List<int> cycleList = new List<int>();
        DFS(nodes[1], new HashSet<int>(), new List<int>(), ref cycleList, ref hasFoundCycle, -1);
        List<int[]> edgesForCycle = GetEdgesForCycleList(cycleList);
        for (int i = edges.Length - 1; i >=0; i--) {
            int[] currentEdge = edges[i];
            foreach (int[] cycleEdge in edgesForCycle) {
                if ((cycleEdge[0] == currentEdge[0] && cycleEdge[1] == currentEdge[1]) || (cycleEdge[0] == currentEdge[1] && cycleEdge[1] == currentEdge[0])) {
                    return currentEdge;
                }
            }
        }
        return new int[2];
    }

    public void DFS(Node node, HashSet<int> visitedSet, List<int> pathList, ref List<int> cycleList, ref bool hasFoundCycle, int prevNodeValue) {
        if (node == null) return;
        if (hasFoundCycle) return;
        bool addedToVisitedSet = visitedSet.Add(node.value);
        pathList.Add(node.value);
        if (!addedToVisitedSet) {
            // Detected a cycle with node.value, find the first apperance of node.value and here are all the possible edges
            hasFoundCycle = true;
            (int startingIndex, int endingIndex) = GetIndexesForCyclePath(pathList);
            cycleList = pathList.GetRange(startingIndex, endingIndex - startingIndex);
            return;
        }
        foreach (Node homie in node.homies) {
            if (homie.value == prevNodeValue) continue;
            DFS(homie, visitedSet, pathList, ref cycleList, ref hasFoundCycle, node.value);
        }
        visitedSet.Remove(node.value);
        pathList.RemoveAt(pathList.Count - 1);
    }

    public (int startingIndex, int endingIndex) GetIndexesForCyclePath(List<int> pathInNodes) {
        int reoccuringNodeValue = pathInNodes.Last();
        int indexOfFirstOccurence = pathInNodes.IndexOf(reoccuringNodeValue);
        return (indexOfFirstOccurence, pathInNodes.Count - 1);
    }

    public List<int[]> GetEdgesForCycleList(List<int> cycleList) {
        List<int[]> edges = new List<int[]>();
        for (int i = 0; i < cycleList.Count - 1; i++) {
            int[] edge = new int[] {cycleList[i], cycleList[i + 1]};
            edges.Add(edge);
        }
        // Since its a cycle, we gotta add the edge that connects the last to the first as well
        edges.Add(new int[] {cycleList[0], cycleList[cycleList.Count - 1]});
        return edges;
    }
}
