public class Solution {
    public int[][] KClosest(int[][] points, int k) {
        // My thoughts, will need a heap to be able to get k closest points for sure
        // We can create a max heap with size k,
        // We should iterate throught the points and calculate the distance and use that distance as priority for the heap
        // When heap size goes above k, we can dequeue the max value and as a result, we would have k smallest values
        //
        // What if two points are in same distance but they there are k - 1 closer point therefore, same distance for the kth and (k + 1)th element as a result we dont know which one to consider the kth? 
        // Ohhh okay the questions mentionas that the answer is guaranteed to be unique and this is exactly why they mention it
        // int[] distances = new int[points.Length];
        PriorityQueue<int[], int> maxHeap = new PriorityQueue<int[], int>();
        for (int i = 0; i < points.Length; i++) {
            int[] point = points[i];
            (int xDistance, int yDistance) = (Math.Abs(point[0]), Math.Abs(point[1]));
            int distanceSquare = ((int)Math.Pow(xDistance, 2) + (int)Math.Pow(yDistance, 2));
            maxHeap.Enqueue(point, -distanceSquare);
            if (maxHeap.Count > k) {
                maxHeap.Dequeue();
            }
        }
        // O(N * logk) in worst case k can be N so
        // O(N * logN)

        int[][] result = new int[k][];
        for (int i = 0; i < k; i++) {
            if (maxHeap.Count > 0) {
                int[] point = maxHeap.Dequeue();
                result[i] = point;
            } 
        }
        return result;
    }
}
