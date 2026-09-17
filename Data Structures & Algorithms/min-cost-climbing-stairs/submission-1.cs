public class Solution {
    public int MinCostClimbingStairs(int[] cost) {
        // This again sounds like a decision tree
        // But this time, what we gotta do is, probably explore all the possible ways and get the min
        // Well, is that actually the case? I guess if you are at the last step or the one before that, you can pay those corresponding values and finish climbing so, these do become the basecase right?
        // So, we can start building on top of them? 
        // So the cost for a step is, itself + min(next step's cost, next next step's cost)

        // Okay time limit exceeded for my submission, so I gotta do some optimizations, probably memoization
        int[] stepAccCosts = new int[cost.Length];
        for (int i = 0; i < stepAccCosts.Length; i++) {
            stepAccCosts[i] = -1;
        }
        int costFrom0 = DT(0, cost, 0, stepAccCosts);
        int costFrom1 = DT(1, cost, 0, stepAccCosts);
        return costFrom0 > costFrom1 ? costFrom1 : costFrom0;
    }

    public int DT(int stepIndex, int[] cost, int runningCost, int[] stepAccCosts) {
        if (stepIndex >= cost.Length) return runningCost;
        if (stepIndex >= cost.Length - 2) return runningCost + cost[stepIndex];
        if (stepAccCosts[stepIndex] != -1) return stepAccCosts[stepIndex];
        int currentStepsCost = cost[stepIndex] + Math.Min(DT(stepIndex + 1, cost, runningCost, stepAccCosts), DT(stepIndex + 2, cost, runningCost, stepAccCosts));
        stepAccCosts[stepIndex] = currentStepsCost;
        return currentStepsCost;
    }
}
