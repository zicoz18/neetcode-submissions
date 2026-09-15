public class Solution {
    // Start at 16:45
    public int[] MaxSlidingWindow(int[] nums, int k) {
        int[] results = new int[nums.Length - k + 1];
        PriorityQueue<int, int> maxQueue = new PriorityQueue<int, int>(Comparer<int>.Create((x, y) => y.CompareTo(x)));
        for (int windowSize = 0; windowSize < k; windowSize++) {
            maxQueue.Enqueue(nums[windowSize], nums[windowSize]);
        }
        int localMax = maxQueue.Peek();
        results[0] = localMax;

//////// DOUBLE QUEUE LOGIC ///////// 
// One queue holds the values one queue holds the current max
// Well, could not figure it out
// MAYBE try heap???

//////// HEAP LOGIC ////////
        

        for (int leftPointer = 1; leftPointer < nums.Length - k + 1; leftPointer++) {
            int rightPointer = leftPointer + k - 1;
            int rightValue = nums[rightPointer];
            int deletedValue = nums[leftPointer - 1];
            maxQueue.Remove(deletedValue, out int removedElement, out int removedElementPriority);
            maxQueue.Enqueue(rightValue, rightValue);
            int maxOfQueue = maxQueue.Peek();
            results[leftPointer] = maxOfQueue;
        }
        // Time complexity is O(nums.Length * k)
        return results;
    }
}
