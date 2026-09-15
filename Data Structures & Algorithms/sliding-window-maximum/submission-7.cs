public class Solution {
    // Start at 16:45
    public int[] MaxSlidingWindow(int[] nums, int k) {
        int[] results = new int[nums.Length - k + 1];
        PriorityQueue<int, int> maxQueue = new PriorityQueue<int, int>(Comparer<int>.Create((x, y) => y.CompareTo(x)));
        for (int windowSize = 0; windowSize < k; windowSize++) {
            maxQueue.Enqueue(windowSize, nums[windowSize]);
        }
        int localMaxIndex = maxQueue.Peek();
        results[0] = nums[localMaxIndex];

//////// DOUBLE QUEUE LOGIC ///////// 
// One queue holds the values one queue holds the current max
// Well, could not figure it out
// MAYBE try heap???

//////// HEAP LOGIC ////////
        

        for (int leftPointer = 1; leftPointer < nums.Length - k + 1; leftPointer++) {
            int rightPointer = leftPointer + k - 1;
            int rightValue = nums[rightPointer];
            maxQueue.Enqueue(rightPointer, rightValue);
            int indexOfMaxValue = -1;
            if (maxQueue.TryPeek(out int indexOfMaxValue0, out int maxValue0)) {
                indexOfMaxValue = indexOfMaxValue0;
                while (indexOfMaxValue < leftPointer) {
                    maxQueue.Dequeue();
                    maxQueue.TryPeek(out int indexOfMaxValue1, out int maxValue1);
                    indexOfMaxValue = indexOfMaxValue1;
                }
            }
            int indexOfMax = maxQueue.Peek();
            int maxOfQueue = nums[indexOfMax];
            results[leftPointer] = maxOfQueue;
        }
        // Time complexity is O(nums.Length * k)
        return results;
    }
}
