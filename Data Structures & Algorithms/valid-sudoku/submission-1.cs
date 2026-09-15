public class Solution {
    public int ROW_COUNT = 9;
    public int COLUMN_COUNT = 9;

    public bool IsValidSudoku(char[][] board) {
        int rowCount = 9;
        int columnCount = 9;
        for (int row = 0; row < rowCount; row++) {
            for (int column = 0; column < columnCount; column++) {
                bool isValidCell = IsValidCell(row, column, board);
                if (!isValidCell) return false; 
            }
        }
        return true;
    }

    public bool IsValidCell(int row, int column, char[][] board) {
        bool isValidRow = IsValidRow(row, column, board);
        bool isValidColumn = IsValidColumn(row, column, board);
        bool isValidBox = IsValidBox(row, column, board);
        return isValidRow && isValidColumn && isValidBox;
    }

    public bool IsValidRow(int row, int column, char[][] board) {
        int givenCellsValue = board[row][column];
        if (givenCellsValue == '.') return true;
        for (int currentColumn = 0; currentColumn < COLUMN_COUNT; currentColumn++) {
            if (currentColumn == column) continue;
            int currentCellsValue = board[row][currentColumn];
            if (currentCellsValue == givenCellsValue) {
                // Console.WriteLine("Returning False inside IsValidRow for: row, column, currentColumn: " + row + ", " + column + ", " + currentColumn);
                return false;
            }
        }
        return true;
    }

    public bool IsValidColumn(int row, int column, char[][] board) {
        int givenCellsValue = board[row][column];
        if (givenCellsValue == '.') return true;
        for (int currentRow = 0; currentRow < ROW_COUNT; currentRow++) {
            if (currentRow == row) continue;
            int currentCellsValue = board[currentRow][column];
            if (currentCellsValue == givenCellsValue) {
                // Console.WriteLine("Returning False inside IsValidColumn for: row, column, currentRow: " + row + ", " + column + ", " + currentRow);
                return false;
            }
        }
        return true;
    }

    public bool IsValidBox(int row, int column, char[][] board) {
        int givenCellsValue = board[row][column];
        if (givenCellsValue == '.') return true;
        int BOX_MULTIPLIER = 3;
        int rowBase = (row / 3) * BOX_MULTIPLIER;
        int columnBase = (column / 3) * BOX_MULTIPLIER;
        for (int currentRow = rowBase; currentRow < rowBase + 3; currentRow++) {
            for (int currentColumn = columnBase; currentColumn < columnBase + 3; currentColumn++) {
                if (currentRow == row && currentColumn == column) {
                    continue;
                }
                int currentCellsValue = board[currentRow][currentColumn];
                if (currentCellsValue == givenCellsValue) {
                    // Console.WriteLine("Returning False inside IsValidBox for: row, column, currentRow, currentColumn: " + row + ", " + column + ", " + currentRow + ", " + currentColumn);
                    return false;
                }
            }
        }
        return true;
    }
}
