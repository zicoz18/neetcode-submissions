public class Solution {
    public readonly (int x, int y)[] directions = {(1, 0), (-1, 0), (0, 1), (0, -1)};

    public List<List<int>> PacificAtlantic(int[][] heights) {
        // One way to solve this might be trying to solve each level starting from the lowest one
        // For the given example, we will traverse the grid and put each height to its own bucket
        // We will start by processing 2s (lowest level) to see if they reach both seas
        // If any can do, we will start a new search from that, 
        // because if a cell with a lower level can reach the seas, any neighboring cell with a higher level will be reaching both seas as well
        // we will do this till we have visited every cell or have searched for every level


        // Another option might be, starting from the highest level? and try to find their reach? but this does seem to be processing way more stuff

        int ROWS = heights.Length;
        int COLS = heights[0].Length;
        Dictionary<int, List<(int x, int y)>> heightToCells = new Dictionary<int, List<(int x, int y)>>();
        int minHeight = -1;
        int maxHeight = -1;
        List<List<int>> results = new List<List<int>>();
        bool[][] hasAccessToBothSeas = new bool[ROWS][];
        bool[][] hasVisited = new bool[ROWS][];


        for (int r = 0; r < ROWS; r++) {
            hasAccessToBothSeas[r] = new bool[COLS];
            hasVisited[r] = new bool[COLS];
            for (int c = 0; c < COLS; c++) {
                int currentHeight = heights[r][c];
                if (minHeight == -1 || currentHeight < minHeight) {
                    minHeight = currentHeight;
                }
                if (maxHeight == -1 || currentHeight > maxHeight) {
                    maxHeight = currentHeight;
                }
                if (heightToCells.TryGetValue(currentHeight, out List<(int x, int y)> heightList)) {
                    heightList.Add((r, c));
                } else {
                    heightToCells[currentHeight] = new List<(int x, int y)>();
                    heightToCells[currentHeight].Add((r, c));
                }
            }
        }

        for (int height = minHeight; height <= maxHeight; height++) {
            if (heightToCells.TryGetValue(height, out List<(int x, int y)> cellsForCurrentHeight)) {
                foreach (var cell in cellsForCurrentHeight) {
                    bool hasAccessedAtlantic = false;
                    bool hasAccessedPacific = false;
                    DFS(cell, ref hasAccessedAtlantic, ref hasAccessedPacific, heights, hasAccessToBothSeas, hasVisited);
                    if (hasAccessedAtlantic && hasAccessedPacific) {
                        results.Add(new List<int>{cell.x, cell.y});
                        hasAccessToBothSeas[cell.x][cell.y] = true;
                    }
                    ClearHasVisited(hasVisited);
                }

            }
        }

        return results;
    }   

    public void DFS((int x, int y) cell, ref bool hasAccessedAtlantic, ref bool hasAccessedPacific, int[][] grid, bool[][] hasAccessToBothSeas, bool[][] hasVisited) {
        if (hasVisited[cell.x][cell.y]) return;
        hasVisited[cell.x][cell.y] = true;
        if (hasAccessedAtlantic && hasAccessedPacific) return;

        foreach (var direction in directions) {
            (int x, int y) newCell = (cell.x + direction.x, cell.y + direction.y);
            if (newCell.x >= grid.Length || newCell.y >= grid[0].Length) {
                hasAccessedAtlantic = true;
                continue;
            }
            if (newCell.x < 0 || newCell.y < 0) {
                hasAccessedPacific = true;
                continue;
            }
            if (CanFlow(cell, newCell, grid)) {
                if (hasAccessToBothSeas[newCell.x][newCell.y]) {
                    hasAccessedAtlantic = true;
                    hasAccessedPacific = true;
                    return;
                }
                DFS(newCell, ref hasAccessedAtlantic, ref hasAccessedPacific, grid, hasAccessToBothSeas, hasVisited);
            }
        }
    }

    public bool CanFlow((int x, int y) startingCell, (int x, int y) targetCell, int[][] grid) {
        return grid[startingCell.x][startingCell.y] >= grid[targetCell.x][targetCell.y];
    }

    public void ClearHasVisited(bool[][] hasVisited ) {
        for (int r = 0; r < hasVisited.Length; r++) {
            for (int c = 0; c < hasVisited[0].Length; c++) {
                hasVisited[r][c] = false;
            }
        }
    }


}
