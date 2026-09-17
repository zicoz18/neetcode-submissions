public class Solution {
    public int ClimbStairs(int n) {     
        // I have couple ideas
        // 1: Decision three type of thing
        // Like its fixed that we can either climb 1 or 2 stairs as a decision
        // So, we will choose one of them till we reach N
        // 2: Combinations, permutation type of thing
        // Like we can achieve N by using n times 1 and 0 times 2 or 0 times 1 and n/2 times 2
        // These are the extreme values and we can try to get all the values in between them like
        // using n - 2 times 1 and 1 times 2, then comes another question which is, how many different ways to order these? So, this might be a solution as well
        // For now, my first idea feels easier to implement so I will try that

        // Okay, tried to submit and looks like time limit got exceeded
        // First thing comes to my mind is just memoization, so caching values for remainingTarget values so they dont get recalculated

        int target = n;
        int remainingTarget = target;
        Dictionary<int, int> targetToDecisionCount = new Dictionary<int, int>();
        return DT(remainingTarget, targetToDecisionCount);
    }

    int[] possibleDecisions = {1, 2};

    public int DT(int remainingTarget, Dictionary<int, int> targetToDecisionCount) {
        if (remainingTarget <= 0) return 0;
        if (remainingTarget == 1) return 1;
        if (remainingTarget == 2) return 2;
        if (targetToDecisionCount.ContainsKey(remainingTarget)) {
            return targetToDecisionCount[remainingTarget];
        }
        int count = 0;
        foreach (int decision in possibleDecisions) {
            count += DT(remainingTarget - decision, targetToDecisionCount);
        }
        targetToDecisionCount[remainingTarget] = count;
        return count;
    }
}
