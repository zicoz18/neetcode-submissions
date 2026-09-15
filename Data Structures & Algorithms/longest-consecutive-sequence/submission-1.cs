public class Solution {
    public int LongestConsecutive(int[] nums) {
        int len = nums.Length;
        HashSet<int> numsSet = new HashSet<int>(nums);
   
        int maxSeqLen = 0;
        foreach (int num in numsSet) {
            if (!numsSet.Contains(num - 1)) {
                // seq starter
                int currentSequenceLength = 0;
                int currentNum = num;
                while (numsSet.Contains(currentNum)) {
                    currentSequenceLength++;
                    currentNum++;
                }
                if (currentSequenceLength > maxSeqLen) {
                    maxSeqLen = currentSequenceLength;
                } 
            }
        }

        return maxSeqLen;

    }
}
