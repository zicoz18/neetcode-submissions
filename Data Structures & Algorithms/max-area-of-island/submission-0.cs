public class Solution {
    public int[][] _grid;

    public (int, int)[] directions = {(1, 0), (-1, 0), (0, 1), (0, -1)};

    public int MaxAreaOfIsland(int[][] grid) {
        // iterate through the 2d array
        // whenever you see a "1" you go ahead and explore that island
        // when exploring, you mark them visited
        // you skip visited ones both when iterating through the array and exploring the island
        // as a result, we will explore each island only once and explore every island
        // What I have to extra is, have the info related to island's size
        // I could either pass along the island as list of r,c values or I might just pass along the size
        // We will see how it goes
        _grid = grid;
        int maxIslandSize = 0;

        bool[][] isVisited = new bool[grid.Length][];
        for (int i = 0; i < isVisited.Length; i++) {
            isVisited[i] = new bool[grid[0].Length];
        }

        for (int r = 0; r < grid.Length; r++) {
            for (int c = 0; c < grid[0].Length; c++) {
                bool visited = isVisited[r][c];
                if (visited) continue;
                if (!isLand(r, c)) {
                    isVisited[r][c] = true;
                } else {
                    int islandSize = 0;
                    GetIslandSize(r, c, ref islandSize, isVisited);
                    if (islandSize > maxIslandSize) maxIslandSize = islandSize;
                }
            }
        }

        return maxIslandSize;
    }

    public void GetIslandSize(int row, int col, ref int currentSize, bool[][] isVisited) {
        if (row < 0 || row >= _grid.Length || col < 0 || col >= _grid[0].Length) return;
        if (isVisited[row][col]) return;
        if (!isLand(row ,col)) return;
        currentSize++;
        isVisited[row][col] = true;
        foreach ((int, int) direction in directions) {
            GetIslandSize(row + direction.Item1, col + direction.Item2, ref currentSize, isVisited);
        }
    } 

    public bool isLand(int row, int col) {
        return _grid[row][col] == 1;
    }
}
