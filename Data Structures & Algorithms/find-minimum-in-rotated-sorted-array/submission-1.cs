public class Solution {
    public int FindMin(int[] nums) {
        int currentMin = 0;
        bool isMinInitialized = false;
        for (int i = 0; i < nums.Length; i++) {
            if (!isMinInitialized) {
                currentMin = nums[i];
                isMinInitialized = true;
            } else {
                int currentValue = nums[i];
                if (currentValue < currentMin) {
                    currentMin = currentValue;
                } 
            }
        }

        return currentMin;
    }
}
