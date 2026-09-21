public class Solution {
    public bool CanPartition(int[] nums) {
        
        // What I have in mind initially is, iterate the array to find the sum
        // if sum is odd, just return false
        // so from now on, we know sum is even
        // then, we divide the sum to 2, and have goal sum as sum/2 for subsets
        // Then, I will try to find elements to sum up to sum/2, when I do so, I will check if the remaining elements sum up to sum/2 as well. if thats the case return true, otherwise return false
        // I will do this with a decision tree (DT) where we will have an index that gets increasing with each decision
        // and decision itself is either including the current index or not
        // As a result, I will have to check 2^n nodes, so this will probably exceed the time limit, but lets try it first
        // Then, we can consider memoization and potential optimizations
        int sum = 0;
        for (int i = 0; i < nums.Length; i++) {
            sum += nums[i];
        }
        if (sum % 2 == 1) return false;
        int targetSumForSubset = sum / 2;
        (bool isValid, bool[] usedArray)?[,] memo = new (bool isValid, bool[] usedArray)?[nums.Length + 1, sum / 2 + 1];
        (bool isValid, bool[] usedArray) = DT(nums, 0, 0, targetSumForSubset, new bool[nums.Length], memo);
        if (!isValid) return false;
        int runningSum = 0;
        for (int i = 0; i < usedArray.Length; i++) {
            if (!usedArray[i]) runningSum += nums[i];
        }
        return runningSum == targetSumForSubset;
    }

    public (bool, bool[]) DT(int[] nums, int index, int runningSum, int targetSum, bool[] usedArray, (bool isValid, bool[] usedArray)?[,] memo) {
        if (runningSum == targetSum) return (true, (bool[])usedArray.Clone());
        if (runningSum > targetSum) return (false, new bool[0]);
        if (index >= nums.Length) return (false, new bool[0]);
        int num = nums[index];
        int remainingTarget = targetSum - runningSum;
        if (memo[index, remainingTarget] != null) {
            return ((bool isValid, bool[] usedArray))memo[index, remainingTarget];
        }
        usedArray[index] = true;
        (bool isValid1, bool[] usedIndexes1) = DT(nums, index + 1, runningSum + num, targetSum, usedArray, memo);
        usedArray[index] = false;
        (bool isValid0, bool[] usedIndexes0) = DT(nums, index + 1, runningSum, targetSum, usedArray, memo);
        (bool isValid, bool[] usedIndexes) returnValue;
        if (isValid0 && isValid1) {
            returnValue = (true, usedIndexes0);
        } else if (isValid0) {
            returnValue = (true, usedIndexes0);
        } else if (isValid1) {
            returnValue = (true, usedIndexes1);
        } else {
            returnValue = (false, new bool[0]);
        }
        memo[index, remainingTarget] = (returnValue.isValid, (bool[])returnValue.usedIndexes.Clone());
        return returnValue;
    }
}
