public class Solution {
    public int Search(int[] nums, int target) {
        int counter = 0;


        int leftPointer = 0;
        int rightPointer = nums.Length - 1;
        while (leftPointer <= rightPointer) {
            int midPointer = (leftPointer + rightPointer) / 2;

            int midValue = nums[midPointer];
            int leftValue = nums[leftPointer];
            int rightValue = nums[rightPointer];
            Console.WriteLine("L: " + leftValue + ", R: " + rightValue + ", M: " + midValue);

            if (target == midValue) return midPointer;
            if (target == leftValue) return leftPointer;
            if (target == rightValue) return rightPointer;
            if (leftPointer == midPointer && midPointer == rightPointer) return -1;

            if (leftValue < midValue && midValue < rightValue) {
                // all in rotation
                if (target < leftValue || target > rightValue) return -1;
                if (target < midValue) {
                    rightPointer = midPointer - 1;
                } else {
                    leftPointer = midPointer + 1;
                }

            } else if (leftValue < midValue) {
                // midValue <> rightValue there is the rotation index
                if (target < midValue && target > leftValue) {
                    rightPointer = midPointer - 1;
                } else {
                    leftPointer = midPointer + 1;
                }
            } else if (midValue < rightValue) {
                // leftValue <> midValue there is the rotation
                if (target > midValue && target < rightValue) {
                    leftPointer = midPointer + 1;
                } else {
                    rightPointer = midPointer - 1;
                }
            }
            counter++;
            if (counter > 20) return -1;
        }
        return -1;
    }
}
