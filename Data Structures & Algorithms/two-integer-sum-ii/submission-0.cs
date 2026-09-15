public class Solution {
    public int[] TwoSum(int[] numbers, int target) {
        int leftPointer = 0;
        int rightPointer = numbers.Length - 1;
        while (leftPointer < rightPointer) {
            int leftValue = numbers[leftPointer];
            int rightValue = numbers[rightPointer];
            int currentSum = leftValue + rightValue;
            if (currentSum == target) {
                break;
            } else if (currentSum > target) {
                rightPointer--;
            } else {
                leftPointer++;
            }
        }
        return new int[2] {leftPointer + 1, rightPointer + 1};
    }
}
