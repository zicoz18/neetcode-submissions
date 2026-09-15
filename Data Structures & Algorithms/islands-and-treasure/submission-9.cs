public class Solution {
    public const int INF = 2147483647;

    public static readonly (int x,int y)[] directions = {(1, 0), (-1, 0), (0, 1), (0, -1)};

    public void islandsAndTreasure(int[][] grid) {
        Queue<(int x, int y)> queue = new Queue<(int x, int y)>();

        for (int r = 0; r < grid.Length; r++) {
            for (int c = 0; c < grid[0].Length; c++) {
                int positionValue = grid[r][c];
                if (positionValue != 0) {
                    continue;
                }
                queue.Enqueue((r, c));
            }
        }
        if (queue.Count == 0) return;
        BFS(queue, grid);
    }


    public void BFS(Queue<(int x,int y)> queue, int[][] grid) {
        while (queue.Count > 0) {
            (int x, int y) cell = queue.Dequeue();
            foreach ((int x, int y) direction in directions) {
                int newX = cell.x + direction.x;
                int newY = cell.y + direction.y;
                if (newX < 0 || newX >= grid.Length || newY < 0 || newY >= grid[0].Length) continue;
                int newPositionsValue = grid[newX][newY];
                if (newPositionsValue != INF) {
                    continue;
                }  
                queue.Enqueue((newX, newY));
                grid[newX][newY] = grid[cell.x][cell.y] + 1;
            }       
        }
    }
}
