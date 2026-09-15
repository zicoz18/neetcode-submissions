public class Solution {
    public int FindDuplicate(int[] nums) {
        int slowPointer = 0;
        int fastPointer = 0;
        do {
            slowPointer = nums[slowPointer];
            fastPointer = nums[nums[fastPointer]];
            // Console.WriteLine("Slow: " + slowPointer);
            // Console.WriteLine("Fast: " + fastPointer);
        } while (slowPointer != fastPointer);
        int extraSlowPointer = 0;
        do {
            slowPointer = nums[slowPointer];
            extraSlowPointer = nums[extraSlowPointer];
            // Console.WriteLine("Slow: " + slowPointer);
            // Console.WriteLine("ExtraSlow: " + extraSlowPointer);
        } while (slowPointer != extraSlowPointer);
        return slowPointer;
    }
}
