public class Solution {
    public int[] ProductExceptSelf(int[] nums) {
        int[] results = new int[nums.Length];
        int product = 1;
        int productWithoutZeroMultiplication = 1;
        int zeroCount = 0;
        for (int i = 0; i < nums.Length; i++) {
            if (nums[i] != 0) {
                productWithoutZeroMultiplication = productWithoutZeroMultiplication * nums[i];
            } else {
                zeroCount++;
            }
            product *= nums[i];
        }
        for (int i = 0; i < nums.Length; i++) {
            if (zeroCount > 1) {
                results[i] = 0;
                continue;
            } 
            if (nums[i] == 0) {
                results[i] = productWithoutZeroMultiplication;
            } else {
                int productExceptSelf = product / nums[i];
                results[i] = productExceptSelf;
            }
        }
        return results;
    }
}
