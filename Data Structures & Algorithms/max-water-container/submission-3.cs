public class Solution {
    public int MaxArea(int[] heights) {
        // Okay, we have solved it in O(N^2) time using nested loops, how can we optimize it?
        // I guess, we can start assuming our left wall is the starting one, and our right wall is the ending one
        int maxArea = -1;
        int leftPointer = 0;
        int rightPointer = heights.Length - 1;
        while (leftPointer < rightPointer) {
            int width = rightPointer - leftPointer;
            int leftHeight = heights[leftPointer];
            int rightHeight = heights[rightPointer];
            int height = Math.Min(leftHeight, rightHeight);
            int area = width * height;
            if (area > maxArea) {
                maxArea = area;
            }
            if (leftHeight < rightHeight) {
                leftPointer++;
            } else {
                rightPointer--;
            }
        }
        return maxArea;
    }
}
