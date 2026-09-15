public class Solution {
    public int Search(int[] nums, int target) {
        int leftPointer = 0;
        int rightPointer = nums.Length - 1;
        while (leftPointer <= rightPointer) {
            int midPointer = (leftPointer + rightPointer + 1) / 2;
            int midValue = nums[midPointer];
            if (leftPointer + 1 == rightPointer || leftPointer == rightPointer) {
                int leftValue = nums[leftPointer];
                int rightValue = nums[rightPointer];
                if (leftValue == target) return leftPointer; 
                if (rightValue == target) return rightPointer; 
                return -1;
            }
            if (midValue == target) {
                return midPointer;
            } else if (midValue < target) {
                leftPointer = midPointer;
            } else {
                rightPointer = midPointer;
            }
        }
        return -1;
    }
}
