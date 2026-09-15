public class Solution {
    public static readonly (int x, int y)[] directions = {(1, 0), (-1, 0), (0, 1), (0, -1)};

    public int OrangesRotting(int[][] grid) {
        // Count the fresh and rotten fruits at the begining

        // Start from rotten fruit(s), if there are multiple do multiple
        // Do BFS to fresh fruits, if in a single cycle, the rotten count does not change and rotten count != total fruit count return -1
        // If rotten count == total fruit count return BFS level
        int ROWS = grid.Length;
        int COLS = grid[0].Length;

        Queue<(int x, int y)> queue = new Queue<(int x, int y)>();
        int initialFreshFruitCount = 0;

        for (int r = 0; r < ROWS; r++) {
            for (int c = 0; c < COLS; c++) {
                int val = grid[r][c];
                if (val == 1) {
                    initialFreshFruitCount++;
                } else if (val == 2) {
                    queue.Enqueue((r, c));
                }
            }
        }

        int initialRottenFruitCount = queue.Count;
        int totalFruitCount = initialFreshFruitCount + initialRottenFruitCount;

        int currentRottenCount = initialRottenFruitCount;
        int currentFreshCount = initialFreshFruitCount;

        int minutesPassed = 0;
        if (initialFreshFruitCount == 0) return 0;
        if (initialRottenFruitCount == 0) return -1;
        while (queue.Count > 0) {
            int searchLevelItemCount = queue.Count;
            int rottenCountBeforeLevel = currentRottenCount;
            int freshCountBeforeLevel = currentFreshCount;
            // Console.WriteLine("At minutesPassed: " + minutesPassed + ", there are " + searchLevelItemCount);
            for (int i = 0; i < searchLevelItemCount; i++) {
                (int x, int y) cell = queue.Dequeue();
                foreach((int x, int y) direction in directions) {
                    int newX = cell.x + direction.x;
                    int newY = cell.y + direction.y;
                    // if (IsOutOfBounds(newX, newY, grid) || !IsFreshFruit(newX, newY, grid)) continue;
                    if (IsOutOfBounds(newX, newY, grid)) continue;
                    if (!IsFreshFruit(newX, newY, grid)) continue;
                    RotFruit(newX, newY, ref currentRottenCount, ref currentFreshCount, grid);
                    queue.Enqueue((newX, newY));
                }
            }
            minutesPassed++;
            if (currentRottenCount == totalFruitCount) break;
            if (currentRottenCount == rottenCountBeforeLevel) return -1;
        }
        return minutesPassed;


    }

    public void RotFruit(int x, int y, ref int currentRottenCount, ref int currentFreshCount, int[][] grid) {
        currentRottenCount++;
        currentFreshCount--;
        grid[x][y] = 2;
    }

    public bool IsOutOfBounds(int x, int y, int[][] grid) {
        if (x < 0 || x >= grid.Length) return true;
        if (y < 0 || y >= grid[0].Length) return true;
        return false;
    }
    
    public bool IsFreshFruit(int x, int y, int[][] grid) {
        return grid[x][y] == 1;
    }


}
