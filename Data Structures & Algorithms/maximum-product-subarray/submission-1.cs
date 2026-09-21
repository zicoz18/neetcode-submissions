public class Solution {
    public int MaxProduct(int[] nums) {
        // First thing that comes to my mind is, brute forcing it
        // So basically, discover each subarray and compute product of each
        // But, I guess this is not the expected solution and we do expect a more efficient solution
        // Hmmm, how about we try to find the max product subarray for each index?
        // Like for the example [2, 4, -3, 5]
        // What we can do is, check starting from value 2
        // so left pointer is at 2 and right pointer is at 2 as well
        // currently the max value is 2, then we move the right pointer till the end and find the max product subarray that starts at 2
        // Maybe an even better solution might be starting from the right side
        // Like starting from 5, with left and righgt pointers being there
        // Then since we cant move right pointer more, we will say that max sub array that starts with the index of 5 is 5
        // Then we start the left and right pointer from -3, and then since we already know the max product sum subarray that starts from 5 is 5, we can basically say that for -3, it can either be directly -3 or -15
        // Then we start left and right pointer from 4, we know that it can be directly 4 or based on our previous work we know that if we go to right we can obtain, -3, -15 so current one's max value is just 4
        // Well, since there are negative values, we gotta keep the min values in mind as well cuz when two negative values get included in the same subarray, the previous min value suddenly becomes useful for new max value. As a result, we gotta keep min, max values for the indexes and when we are considering a new index, we gotta check it by itself, multiplying iy with next index's min and max values

        /////// [2, -4 , -3, 5]
        /////// [(-8, 120) , (-4, 60), (-3, -15), (5, 5)] 

        (int min, int max)[] minMaxValuesStartingFromIndex = new (int min, int max)[nums.Length];

        minMaxValuesStartingFromIndex[nums.Length -1] = (min: nums[nums.Length -1], max: nums[nums.Length -1]);
        int max = minMaxValuesStartingFromIndex[nums.Length -1].max;

        for (int i = nums.Length - 2; i >= 0; i--) {
            int num = nums[i];
            int val0 = num * minMaxValuesStartingFromIndex[i + 1].max;
            int val1 = num * minMaxValuesStartingFromIndex[i + 1].min;
            int val2 = num;
            int min0 = Math.Min(Math.Min(val0, val1), val2);
            int max0 = Math.Max(Math.Max(val0, val1), val2);
            if (max0 > max) {
                max = max0;
            }
            minMaxValuesStartingFromIndex[i] = (min: min0, max: max0);
        }

        return max;
    }
}
