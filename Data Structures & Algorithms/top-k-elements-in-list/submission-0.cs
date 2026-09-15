public class Solution {
    public int[] TopKFrequent(int[] nums, int k) {
        Dictionary<int, int> numberToFrequencyDict = new Dictionary<int, int>();
        // O(n) space and time
        int uniqueNumberCount = 0;
        for (int i = 0; i < nums.Length; i++) {
            int currentNumber = nums[i];
            if (!numberToFrequencyDict.ContainsKey(currentNumber)) {
                numberToFrequencyDict[currentNumber] = 0;
                uniqueNumberCount++;
            }
            numberToFrequencyDict[currentNumber]++;
        }

        // O(n) space and time
        (int, int)[] heapInitArray = new (int, int)[uniqueNumberCount];
        int indexOfHeapInitArray = 0;
        foreach(KeyValuePair<int, int> keyValuePair in numberToFrequencyDict) {
            heapInitArray[indexOfHeapInitArray] = (keyValuePair.Key, keyValuePair.Value);
            indexOfHeapInitArray++;
        }

        // O(n) space and time
        PriorityQueue<int, int> priorityQueue = new PriorityQueue<int, int>(heapInitArray, Comparer<int>.Create((x, y) => y.CompareTo(x)));

        // O(k * logn) time O(1) space
        int[] resultArray = new int[k];
        for (int i = 0; i < k; i++) {
            resultArray[i] = priorityQueue.Dequeue();
        }

        // As a result O(k * logn) or O(N) time and O(N) space
        return resultArray;
    }
}
