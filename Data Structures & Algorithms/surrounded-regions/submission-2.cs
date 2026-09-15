public class Solution {
    public readonly (int x, int y)[] directions = {(1, 0), (-1, 0), (0, 1), (0, -1)};

    public void Solve(char[][] board) {
        // okay, traverse the board's edges
        // whenever you see an 'O', DFS that 'O' to find it's "land"
        // store that land somehow
        // then iterate through the whole board and convert each 'O' thats not in the stored values
        int ROWS = board.Length;
        int COLS = board[0].Length;


        bool[][] partOfEdgeIsland = new bool[ROWS][];
        bool[][] dfsVisited = new bool[ROWS][];
        for (int r = 0; r < ROWS; r++) {
            partOfEdgeIsland[r] = new bool[COLS];
            dfsVisited[r] = new bool[COLS];
        }

        int TOP_ROW = 0;
        int BOTTOM_ROW = ROWS - 1;
        int LEFT_COL = 0;
        int RIGHT_COL = COLS - 1;

        for (int r = 0; r < ROWS; r++) {
            for (int c = 0; c < COLS; c++) {
                if (r == TOP_ROW || r == BOTTOM_ROW || c == LEFT_COL || c == RIGHT_COL) {
                    var cell = (r, c);
                    if (IsCellO(cell, board)) {
                        DFS(cell, board, partOfEdgeIsland, dfsVisited);
                        ClearVisited(dfsVisited);
                    }
                }
            }
        }

        for (int r = 0; r < ROWS; r++) {
            for (int c = 0; c < COLS; c++) {
                if (board[r][c] == 'O' && !partOfEdgeIsland[r][c]) {
                    board[r][c] = 'X';
                }
            }
        }
    }

    public void DFS((int x, int y) cell, char[][] board, bool[][] partOfEdgeIsland, bool[][] dfsVisited) {
        if (IsCellOutOfBounds(cell, board)) return;
        if (dfsVisited[cell.x][cell.y]) return;
        if (!IsCellO(cell, board)) return;
        partOfEdgeIsland[cell.x][cell.y] = true;
        dfsVisited[cell.x][cell.y] = true;
        foreach ((int x, int y) direction in directions) {
            int newX = cell.x + direction.x;
            int newY = cell.y + direction.y;
            DFS((newX, newY), board, partOfEdgeIsland, dfsVisited);
        }
    }

    public bool IsCellOutOfBounds((int x, int y) cell, char[][] board) {
        if (cell.x < 0 || cell.x >= board.Length) return true;
        if (cell.y < 0 || cell.y >= board[0].Length) return true;
        return false;
    }

    public bool IsCellO((int x, int y) cell, char[][] board) {
        return board[cell.x][cell.y] == 'O';
    }

    public void ClearVisited(bool[][] dfsVisited) {
        for (int r = 0; r < dfsVisited.Length; r++) {
            for (int c = 0; c < dfsVisited[0].Length; c++) {
                dfsVisited[r][c] = false;
            }
        }
    }
}
