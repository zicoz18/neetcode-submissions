public class Solution {
    public class Node {
        public int courseNum;
        public List<Node> preReqOf;

        public Node(int _courseNum) {
            courseNum = _courseNum;
            preReqOf = new List<Node>();
        }
    }



    public int[] FindOrder(int numCourses, int[][] prerequisites) {
        // okay yesterday I did the course schedule
        // and for this one, all I have to do differently is to return a valid path
        // what I previoulsy did was, convert the given array to nodes of a graph
        // and then did a DFS to understand if there was a cycle by checking if path touches the same node twice
        // In this case, I guess I gotta do DFS for a course basically return the path
        // But problematic thing right happens when there are seperate graphs
        // I guess, I will DFS each course, store their path? and analyse it afterwards? 
        // If I detect any cycle, I just return an empty array
        Node[] nodes = new Node[numCourses];

        for (int i = 0; i < numCourses; i++) {
            nodes[i] = new Node(i);
        }
        for (int i = 0; i < prerequisites.Length; i++) {
            int[] preReq = prerequisites[i];
            nodes[preReq[0]].preReqOf.Add(nodes[preReq[1]]); // 1 is a preReqOf 0, from 1 you can go to 0
            // nodes[preReq[1]].preReqOf.Add(nodes[preReq[0]]); // 1 is a preReqOf 0, from 1 you can go to 0
        }

        // I guess I will run DFS on each node, store the current DFS's path, if detected a cycle, just return early an empty array
        // Whenever I call the DFS for different nodes from here, I will provide an empty path
        // and they will start building
        // I guess, everytime before 
        int[] seenArray = new int[numCourses];
        List<int> output = new List<int>();

        for (int i = 0; i < numCourses; i++) {
            Node node = nodes[i];
            bool hasDetectedCycle = false;
            List<int> pathList = new List<int>();
            DFS(node, new HashSet<int>(), pathList, seenArray, ref hasDetectedCycle, output);
            if (hasDetectedCycle) return new int[0];
        }

        return output.ToArray();
    }

    int NOT_VISITED = 0;
    int CURRENT_PATH = 1;
    int VISITED_BEFORE = 2;
    int CURRENT_PATH_AND_VISITED_BEFORE = 3;

    public void DFS(Node node, HashSet<int> pathSet, List<int> pathList, int[] seenArray, ref bool hasDetectedCycle, List<int> output) {
        if (node == null) {
            if (seenArray[node.courseNum] == CURRENT_PATH) {
                seenArray[node.courseNum] = VISITED_BEFORE;
                return;
            }
            return;
        };
        if (hasDetectedCycle) {
            if (seenArray[node.courseNum] == CURRENT_PATH) {
                seenArray[node.courseNum] = VISITED_BEFORE;
                return;
            }
            return;
        };
        if (!pathSet.Add(node.courseNum)) {
            // detected cycle
            hasDetectedCycle = true;
            return;
        }; 
        if (seenArray[node.courseNum] == NOT_VISITED) {
            seenArray[node.courseNum] = CURRENT_PATH;
        } else if (seenArray[node.courseNum] == VISITED_BEFORE) {
            return; // already discovered in another path, no need to continue? does this even make sense
            // seenArray[node.courseNum] = CURRENT_PATH_AND_VISITED_BEFORE;
        }
        pathList.Add(node.courseNum);
        foreach (Node preReqOf in node.preReqOf) {
            DFS(preReqOf, pathSet, pathList, seenArray, ref hasDetectedCycle, output);
        }
        pathList.RemoveAt(pathList.Count -1);
        pathSet.Remove(node.courseNum);
        output.Add(node.courseNum);
        if (seenArray[node.courseNum] == CURRENT_PATH) {
            seenArray[node.courseNum] = VISITED_BEFORE;
        }
    }
}
