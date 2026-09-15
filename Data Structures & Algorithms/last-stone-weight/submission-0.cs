public class Solution {
    public int LastStoneWeight(int[] stones) {
        // Build a max heap
        // While there are more than 1 element in the heap,
        // Get 2 elements, if both are equal, continue
        // if one is larger, decrement it by the smaller and re-add it to the heap
        // Return the value in the heap

        (int, int)[] initStones = stones.Select(val => (val, val)).ToArray();

        PriorityQueue<int, int> heap = new PriorityQueue<int, int>(initStones, Comparer<int>.Create((x, y) => y.CompareTo(x)));

        while (heap.Count > 1) {
            int heavyStone = heap.Dequeue();
            int lighterStone = heap.Dequeue();
            int heavyStoneRemaining = heavyStone - lighterStone;
            if (heavyStoneRemaining != 0) {
                heap.Enqueue(heavyStoneRemaining, heavyStoneRemaining);
            }
        }
        if (heap.Count == 0) return 0;
        return heap.Peek();
    }
}
