public class Solution {
    public int Trap(int[] height) {
        int totalTrappedLeft = 0;
        for (int i = 0; i < height.Length - 1; i++) {
            int leftHeight = height[i];
            if (leftHeight != 0) {
                bool didBreak = false;
                int maxRightHeight = -1;
                int maxRightHeightIndex = -1;
                for (int j = i + 1; j < height.Length; j++) {
                    int rightHeight = height[j];
                    if (rightHeight >= maxRightHeight) {
                        maxRightHeight = rightHeight;
                        maxRightHeightIndex = j;
                    }
                    if (rightHeight >= leftHeight) {
                        int currentTrapped = 0;
                        int holdingHeight = leftHeight;
                        for (int k = i + 1; k < j; k++) {
                            currentTrapped += holdingHeight - height[k];
                        }
                        totalTrappedLeft += currentTrapped;
                        i = j - 1;
                        didBreak = true;
                        break;
                    }
                }
                if (!didBreak && maxRightHeightIndex != -1) {
                    for (int j = i + 1; j < maxRightHeightIndex; j++) {
                        int currentRightHeight = height[j];
                        totalTrappedLeft += Math.Max(0, maxRightHeight - currentRightHeight);
                    }
                    i = maxRightHeightIndex - 1;
                }
            }
        }

        return totalTrappedLeft;
    }
}