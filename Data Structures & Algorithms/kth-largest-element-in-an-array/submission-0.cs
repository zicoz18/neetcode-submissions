public class Solution {
        // What we can technically do is, using this array, create a max heap, and then remove k elements to get the kth largest element
        // Time complexity would be O(N) for building a max heap and then O(logN * k) for getting the kth element from the heap
        // As a result, O(N + k * logN)

        // But something even better is using a min heap
        // Rather than initializng the heap with the nums, we will iterate through the array and we will add to the min heap, but if min heap has more than k elements, we do remove the smallest element, as a result, we will end up with k largest elements and doing a single peek would give us the kth largest element
        // In this case, we will perform O(N * logK)


        // Which should be better than previous one in practice
        // But in worst case, where k = n, above one is O(N + k* logN) => O(N * logN) and current one is O(N *logN) as well but except the worst case, we are almost alwasy better
        // Oh also, we do win in space complexity as it would be O(k) for us whereas it will be O(N) for the above one, again in worst case, they will be same tho
    public int FindKthLargest(int[] nums, int k) {
        PriorityQueue<int, int> minHeap = new PriorityQueue<int, int>();
        for (int i = 0; i < nums.Length; i++) {
            int currentNum = nums[i];
            minHeap.Enqueue(currentNum, currentNum);
            if (minHeap.Count > k) {
                minHeap.Dequeue();
            }
        }

        if (minHeap.Count == 0) return -1;
        return minHeap.Peek();

    }
}
