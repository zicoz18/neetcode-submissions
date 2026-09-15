public class Solution {
    public int FindMin(int[] nums) {
        int left = 0;
        int right = nums.Length - 1;
        // int counter = 0;
        while (left <= right) {
            int leftValue = nums[left];
            int rightValue = nums[right];
            Console.WriteLine("leftValue: " + leftValue + ", rightValue: " + rightValue);
            if (leftValue < rightValue) {
                // these are in order
                return nums[left];
            } else if (left == right) {
                return nums[left] < nums[(left + 1) % (nums.Length)] ? nums[left] : nums[(left + 1) % (nums.Length)];
            } else {
                // There is something out of order in between
                int mid = (left + right) / 2;
                int midValue = nums[mid];
                int midLeftValue = mid > 0 ? nums[mid - 1] : nums[mid]; 
                int midRightValue = mid < nums.Length ? nums[mid + 1] : nums[mid];
                Console.WriteLine("midValue: " + midValue);
                if (leftValue <= midLeftValue && midLeftValue >= midValue && midValue <= midRightValue && midRightValue <= rightValue) {
                    return midValue;
                } else if (midValue > rightValue) {
                    // something out of order (mid <> right)
                    left = mid + 1;
                } else if (midValue < leftValue) {
                    // something out of order (left <> mid)
                    right = mid - 1;
                }
            }
            // counter++;
            // if (counter > 10) return -1; 
        }
        return nums[left];
    }
}
