public class Solution {
    public int NumIslands(char[][] grid) {
        // iterate through the whole 2d array
        // if its a 0, skip it
        // if its a 1, search up,down,right,left recursively
        // hold a visited 2d array to indicate you have processed that cell
        // whenever you visit a 0, or 1 cell, mark it visited
        // when iterating, check this visited cell and skip it if its already visited
        // ahhh, actually, when you are iterating through, if you see a cell that is not visited and marked as 1, it counts as a new island and your goal at the end is to keep track of that number, so whenever you see it, increment a value and return that value at the end

        bool[][] isVisited = new bool[grid.Length][];
        for (int i = 0; i < isVisited.Length; i++) {
            isVisited[i] = new bool[grid[0].Length];
        }
        int islandCount = 0;

        for (int r = 0; r < grid.Length; r++) {
            for (int c = 0; c < grid[0].Length; c++) {
                if (isVisited[r][c]) continue;
                // isVisited[r][c] = true;
                bool isLand = GetIsLand(r, c, grid);
                if (isLand) {
                    islandCount++;
                    DiscoverIsland(r, c, grid, isVisited);
                }
            }
        }
        return islandCount;
    }

    public void DiscoverIsland(int row, int col, char[][] grid, bool[][] isVisited) {
        if (row >= grid.Length || row < 0) return;
        if (col >= grid[0].Length || col < 0) return;
        if (isVisited[row][col]) return;
        isVisited[row][col] = true;
        bool isLand = GetIsLand(row, col, grid);
        if (isLand) {
            DiscoverIsland(row + 1, col, grid, isVisited);
            DiscoverIsland(row - 1, col, grid, isVisited);
            DiscoverIsland(row, col + 1, grid, isVisited);
            DiscoverIsland(row, col - 1, grid, isVisited);
        }
    }

    public bool GetIsLand(int row, int col, char[][] grid) {
        return grid[row][col] == '1';
    }

}
