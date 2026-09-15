public class Solution {
    public int[][] KClosest(int[][] points, int k) {
        // My thoughts, will need a heap to be able to get k closest points for sure
        // We can create a min heap with size k,
        // We should iterate throught the points and calculate the distance and use that distance as priority for the heap
        // After building the heap, we should dequeue k elements to receive the points and add them to an array
        (int[], int)[] minHeapInit = new (int[], int)[points.Length];
        for (int i = 0; i < points.Length; i++) {
            int[] point = points[i];
            (int xDistance, int yDistance) = (Math.Abs(point[0]), Math.Abs(point[1]));
            int distanceSquare = (int)Math.Pow(xDistance, 2) + (int)Math.Pow(yDistance, 2);
            minHeapInit[i] = (point, distanceSquare);
        }
        // O(N)

        PriorityQueue<int[], int> minHeap = new PriorityQueue<int[], int>(minHeapInit);
        int[][] result = new int[k][];
        for (int i = 0; i < k; i++) {
            int[] point = minHeap.Dequeue();
            result[i] = point;
        }
        // O(N + k * LogN)
        // techincally k can be N so worst case is O(n * logn)
        return result;
    }
}
