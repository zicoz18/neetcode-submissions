public class Solution {
    public List<List<int>> ThreeSum(int[] nums) {
        // What comes to my mind is, since doing 3 pointer thing where
        // We have left pointer, right pointer and middle pointer
        // rightPointer is constant at right
        // leftPointer gets incremented after each loop of a middle pointer
        // middlePointer starts at leftPointer + 1 and goes till rightPointer - 1 to search for a 3 pair that gets the sum
        // I guess this would not work

        // okay, first thing that comes to mind is doing TwoSum for each num to find it
        // So, we iterate through the nums array, for given index, we assume its used so we are in search of the TwoSum that makes ThreeSum equal 0, we will do this for all the array
        // Since 2Sum itself would take O(N) time and we are doing it for N items, the runtine would be O(N^2)
        // I will implement 2Sum first as a func, and then make use of it inside 3Sum
        // Wait since, our runtime is already O(N^2), what we can do is, check if sorting would help us, because sorting ins O(NlogN) and potentially allows us to do some other things
        // So, lets assume I sorted the input array, than i would be starting with the smallest value
        // Lets do sort and then 3sum nested in 2sum
        // Hmm, how about nested maps? Consider this one as well

        List<List<int>> results = new List<List<int>>();
        HashSet<(int, int, int)> uniqueResults = new HashSet<(int, int, int)>();

        Array.Sort(nums);
        for (int i = 0; i < nums.Length - 2; i++) {
            int currentValue = nums[i];
            int target = -currentValue;
            int leftPointer = i + 1;
            int rightPointer = nums.Length - 1;
            // List<int> resultsForCurrentValue = new List<int>();
            while (leftPointer < rightPointer) {
                int leftValue = nums[leftPointer];
                int rightValue = nums[rightPointer];
                int sum = leftValue + rightValue;
                if (sum == target) {
                    if (uniqueResults.Add((currentValue, leftValue, rightValue))) {
                        results.Add(new List<int> {currentValue, leftValue, rightValue});
                    } 
                    leftPointer++;
                } else if (sum < target) {
                    leftPointer++;
                } else {
                    rightPointer--;
                }
            }
            /*
            List<int> foundTwoSum = SortedTwoSum(nums, target, leftPointer, rightPointer);
            if (foundTwoSum.Count == 2) {
                foundTwoSum.Add(currentValue);
                if (uniqueResults.Add((foundTwoSum[0], foundTwoSum[1], foundTwoSum[2]))) {
                    results.Add(foundTwoSum);
                } 
            }
            */
        }

        return results;
    }

    // Expects to receive sorted nums array
    public List<int> SortedTwoSum(int[] nums, int target, int leftPointer, int rightPointer) {
        while (leftPointer < rightPointer) {
            int leftValue = nums[leftPointer];
            int rightValue = nums[rightPointer];
            int currentSum = leftValue + rightValue;
            if (currentSum == target) {
                return new List<int> {leftValue, rightValue};
            } else if (currentSum < target) {
                leftPointer++;
            } else {
                rightPointer--;
            }
        }
        return new List<int>();
    } 
}
