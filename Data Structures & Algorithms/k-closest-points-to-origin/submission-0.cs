public class Solution {
    public int[][] KClosest(int[][] points, int k) {
        // My thoughts, will need a heap to be able to get k closest points for sure
        // We can create a min heap with size k,
        // We should iterate throught the points and calculate the distance and use that distance as priority for the heap
        // After building the heap, we should dequeue k elements to receive the points and add them to an array
        double[] distances = new double[points.Length];
        (int[], double)[] minHeapInit = new (int[], double)[points.Length];
        for (int i = 0; i < points.Length; i++) {
            int[] point = points[i];
            (int xDistance, int yDistance) = (Math.Abs(point[0]), Math.Abs(point[1]));
            double distance = Math.Sqrt(Math.Pow(xDistance, 2) + Math.Pow(yDistance, 2));
            distances[i] = distance;
            minHeapInit[i] = (point, distance);
        }


        PriorityQueue<int[], double> minHeap = new PriorityQueue<int[], double>(minHeapInit);
        int[][] result = new int[k][];
        for (int i = 0; i < k; i++) {
            int[] point = minHeap.Dequeue();
            result[i] = point;
        }
        return result;
    }
}
