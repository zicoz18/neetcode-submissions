public class Solution {
    public bool SearchMatrix(int[][] matrix, int target) {
        int rowCount = matrix.Length;
        int columnCount = matrix[0].Length;
        int up = 0;
        int down = rowCount - 1;
        while (up <= down) {
            int upDownMiddle = (up + down) / 2;
            // Console.WriteLine("Up: " + up + ", Down: " + down + " Middle: " + upDownMiddle);
            int leftMostValue = GetRowsLeftMostValue(matrix, upDownMiddle);
            int rightMostValue = GetRowsRightMostValue(matrix, upDownMiddle);
            // Console.WriteLine("Left: " + leftMostValue + " Right: " + rightMostValue + " of the row");
            if (target == leftMostValue) return true;
            if (target == rightMostValue) return true;
            if (leftMostValue < target && target < rightMostValue) {
                return IsInThisRow(matrix, upDownMiddle, target);
            } else if (target < leftMostValue) {

                if (upDownMiddle > 0 && target > GetRowsRightMostValue(matrix, upDownMiddle - 1)) {
                    return false;
                }
                down = upDownMiddle - 1;
            } else if (target > rightMostValue) {
                if (upDownMiddle < rowCount - 1 && target < GetRowsLeftMostValue(matrix, upDownMiddle + 1)) {
                    return false;
                }
                up = upDownMiddle + 1;
            } else return false;
        }
        return false;
    }

    public int GetRowsLeftMostValue(int[][] matrix, int rowIndex) {
        return matrix[rowIndex][0];
    }
    public int GetRowsRightMostValue(int[][] matrix, int rowIndex) {
        return matrix[rowIndex][matrix[0].Length - 1];
    }

    public bool IsInThisRow(int[][] matrix, int rowIndex, int target) {
        // Console.WriteLine("IsInThisRow: " + rowIndex);
        int[] row = matrix[rowIndex];
        int l = 0;
        int r = row.Length - 1;
        while (l <= r) {
            int m = (l + r) / 2;
            int mValue = row[m];
            // Console.WriteLine("L: " + l + ", R: " + r + ", M: " + m + ", M Value: " + mValue);
            if (mValue == target) {
                return true;
            } else if (mValue > target) {
                r = m - 1;
            } else {
                l = m + 1;
            }
        }
        return false;
    }
}
