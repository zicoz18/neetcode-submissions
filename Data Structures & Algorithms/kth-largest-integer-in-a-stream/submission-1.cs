public class KthLargest {
    // My thinking: create a min heap, given nums, remove elements untill we have k elements
    // At that point we would basically hold the largest k numbers, so peaking the min heap would mean getting the kth largest number
    // When we are trying to add, we will add to the min heap and then remove the min element and return the peek element to have the kth largest element
    PriorityQueue<int, int> heap;
    int capacity;

    public KthLargest(int k, int[] nums) {
        capacity = k;
        (int, int)[] initArr = new (int, int)[nums.Length];
        for (int i = 0; i < nums.Length; i++) {
            initArr[i] = (nums[i], nums[i]);
        }

        heap = new PriorityQueue<int, int>(initArr);
        while (heap.Count > k) {
            heap.Dequeue();
        }
    }
    
    public int Add(int val) {
        if (heap.Count == capacity) {
            heap.Enqueue(val, val);
            heap.Dequeue();
            return heap.Peek();
        } else {
            heap.Enqueue(val, val);
            return heap.Peek();
        }
    }
}
