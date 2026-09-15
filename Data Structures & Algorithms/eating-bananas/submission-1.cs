public class Solution {
    public int MinEatingSpeed(int[] piles, int h) {
        if (piles.Length == h) {
            return GetMaxValue(piles);
        } else {
            // piles.Length = a
            // h
            // piles.maxValue = b
            // result ~= b / (h / a)
            int maxValue = GetMaxValue(piles);
            // int expectedMin = maxValue / (h / piles.Length);
            int minValue = 1;
            int midValue = (minValue + maxValue) / 2;
            int minEatingRate = maxValue;
            while (minValue <= maxValue) {
                midValue = (minValue + maxValue) / 2;
                int eatingRate = midValue;
                int totalTimeConsumedWithEatingRate = 0;
                for (int i = 0; i < piles.Length; i++) {
                    int currentPilesAmount = piles[i];
                    int timeConsumedForCurrentPile = currentPilesAmount / eatingRate;
                    if (eatingRate * timeConsumedForCurrentPile != currentPilesAmount) timeConsumedForCurrentPile++;
                    totalTimeConsumedWithEatingRate += timeConsumedForCurrentPile;
                }
                if (totalTimeConsumedWithEatingRate <= h) {
                    // potential answer
                    if (eatingRate < minEatingRate) minEatingRate = eatingRate; 
                    // slow down eating rate
                    maxValue = midValue - 1;
                } else if (totalTimeConsumedWithEatingRate > h) {
                    minValue = midValue + 1;
                }
            }
            return minEatingRate;
        }
    }

    public int GetMaxValue(int[] piles) {
        int currentMax = -1;
        for (int i = 0; i < piles.Length; i++) {
            int currentValue = piles[i];
            if (currentValue > currentMax) currentMax = currentValue; 
        }
        return currentMax;
    }

}
