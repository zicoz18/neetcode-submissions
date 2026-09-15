public class Solution {
    public int[] ProductExceptSelf(int[] nums) {
        int[] productLeft = new int[nums.Length];
        int[] productRight = new int[nums.Length];
        for (int leftPointer = 0, rightPointer = nums.Length - 1; leftPointer < nums.Length; leftPointer++, rightPointer--) {
            int previousLeftProduct = leftPointer == 0 ? 1 : productLeft[leftPointer - 1];
            int previousRightProduct = rightPointer == nums.Length - 1 ? 1 : productRight[rightPointer + 1];
            productLeft[leftPointer] = previousLeftProduct * nums[leftPointer];
            productRight[rightPointer] = previousRightProduct * nums[rightPointer];
        }
        int[] products = new int[nums.Length];
        for (int i = 0; i < nums.Length; i++) {
            int leftProduct = i == 0 ? 1 : productLeft[i - 1];
            int rightProduct = i == nums.Length - 1 ? 1 : productRight[i + 1];
            int product = leftProduct * rightProduct;
            products[i] = product;
        }

        return products;
    }
}
