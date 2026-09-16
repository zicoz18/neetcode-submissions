public class Solution {
    public class Node {
        public int value;
        public List<Node> homies;

        public Node(int _value) {
            value = _value;
            homies = new List<Node>();
        }
    }

    public int CountComponents(int n, int[][] edges) {
        // We basically gotta create nodes with adj lists
        // Then we will run DFS on each and when we see a node for the first time, we will increment our counter (DFS will have a ref value and it will set it to true if it ever increments the counter meaning it has founded a new connected component)
        // We are done when our counter hits node count 
        // For each DFS returning true at the loop level, we will increment our connected compoenent count and will return that value


        ////// WAIT, what if there is a cycle? I guess thats a problem for me
        // For now, let me assume that there is no cycle, as they might have not mentioned it with an undirected graph cuz technically any edge creates a cycle
        // But, if a test fails, this is what I gotta keep in mind

        Node[] nodes = new Node[n];
        for (int i = 0; i < n; i++) {
            nodes[i] = new Node(i);
        }
        for (int i = 0; i < edges.Length; i++) {
            int[] edge = edges[i];
            Node node0 = nodes[edge[0]];
            Node node1 = nodes[edge[1]];
            node0.homies.Add(node1);
            node1.homies.Add(node0);
        }

        int totalVisitedCounter = 0;
        bool hasFoundANewGroup = false;
        int groupCount = 0;
        HashSet<int> visitedSetGlobal = new HashSet<int>();

        for (int i = 0; i < n; i++) {
            Node nodeToDFS = nodes[i];
            if (visitedSetGlobal.Contains(nodeToDFS.value)) {
                // already searched so can skip it
                continue;
            }
            DFS(nodeToDFS, ref totalVisitedCounter, ref hasFoundANewGroup, new HashSet<int>(), visitedSetGlobal, -1);
            if (hasFoundANewGroup) {
                groupCount++;
                hasFoundANewGroup = false;
            }
            if (totalVisitedCounter == n) break;
        }
        
        return groupCount;
    }   

    public void DFS(Node node, ref int totalVisitedCounter, ref bool hasFoundANewGroup, HashSet<int> visitedSet, HashSet<int> visitedSetGlobal, int prevNodeValue) {
        if (node == null) return;
        bool addedToVisitedSet = visitedSet.Add(node.value);
        if (!addedToVisitedSet) {
            // we are revisiting node we have already visited in this path, so there is a cycle
            return;
        }
        bool addedToVisitedSetGlobal = visitedSetGlobal.Add(node.value);
        if (addedToVisitedSetGlobal) {
            totalVisitedCounter++;
            hasFoundANewGroup = true;
        } else {
            // we are visiting a node we have already visited in the global set meaning, trying to search an already explored component, so we should just exit
            return;
        }

        foreach (Node homie in node.homies) {
            if (homie.value == prevNodeValue) continue;
            DFS(homie, ref totalVisitedCounter, ref hasFoundANewGroup, visitedSet, visitedSetGlobal, node.value);
        }
        visitedSet.Remove(node.value);
    }
}
