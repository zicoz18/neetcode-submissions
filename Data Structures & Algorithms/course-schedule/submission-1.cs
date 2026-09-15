public class Solution {
    public class Node {
        public int courseNum;
        public List<Node> preReqOf;
        public List<Node> preReq;

        public Node(int _courseNum) {
            courseNum = _courseNum;
            preReqOf = new List<Node>();
            preReq = new List<Node>();
        }
    }

    // Start the cycle from a no prereq one

    public bool CanFinish(int numCourses, int[][] prerequisites) {
        // Well, as I understand, what i have to do is, convert these values to be a graph
        // Kinda like a dependency graph
        // where [[0, 1]] just says to go to 0, I have to be at 1,
        // So, I will create a directed graph with vertexes: 0, 1 and an edge that goes from 1 to 0
        // If it was [[0, 1], [1, 0]] 
        // In this case, there would be a cycle and this is the case where I would return false
        // So, the whole problem is actually creating a graph and detecting if it has a cycle right?
        Node[] nodes = new Node[numCourses];
        for (int i = 0; i < numCourses; i++) {
            nodes[i] = new Node(i);
        }

        for (int i = 0; i < prerequisites.Length; i++) {
            int[] preReqRelation = prerequisites[i];
            int preReqOf = preReqRelation[0]; // 0
            int preReq = preReqRelation[1]; // 1
            nodes[preReqOf].preReq.Add(nodes[preReq]);
            nodes[preReq].preReqOf.Add(nodes[preReqOf]);
        }

        bool[] isFine = new bool[numCourses];
        for (int i = 0; i < numCourses; i++) {
            bool pathAllUnique = DFS(nodes[i], new HashSet<int>(), isFine);
            if (!pathAllUnique) return false;
        }
        return true;
    }

    public bool DFS(Node node, HashSet<int> path, bool[] isFine) {
        if (path.Contains(node.courseNum)) return false;
        if (isFine[node.courseNum]) return true;
        path.Add(node.courseNum);
        List<Node> preReqs = node.preReq;
        foreach (Node preReq in preReqs) {
            bool pathAllUnique = DFS(preReq, path, isFine);
            if (!pathAllUnique) return false;
            path.Remove(preReq.courseNum);
        }
        isFine[node.courseNum] = true;
        return true;
    }
}
