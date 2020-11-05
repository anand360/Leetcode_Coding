using System;

public class MineSweeperBoard
{
    public static int[] dx = new int[] { -1, 0, 1, -1, 1, 0, 1, -1 };
    public static int[] dy = new int[] { -1, 1, 1, 0, -1, -1, 0, 1 };

    public static char[][] Run(char[][] board, int[] click)
    {
        if (board[click[0]][click[1]] == 'M')
        {
            board[click[0]][click[1]] = 'X';
            return board;
        }

        DFS(board, click[0], click[1]);
        return board;
    }

    private static void DFS(char[][] board, int x, int y)
    {
        if (board[x][y] == 'M') { // Mine
            board[x][y] = 'X';
        }
        else { // Empty
            // Get number of mines first.
            int count = 0;
            for (int i = 0; i < 8; i++) {
                int r = x + dx[i], c = y + dy[i];
                if (r < 0 || r >= board.Length || c < 0 || c >= board[0].Length) continue;
                if (board[r][c] == 'M' || board[r][c] == 'X') count++;
            }
            
            if (count > 0) { // If it is not a 'B', stop further DFS.
                board[x][y] = (char)(count + '0');
            }
            else { // Continue DFS to adjacent cells.
                board[x][y] = 'B';
                for (int i = 0; i < 8; i++) {
                    int r = x + dx[i], c = y + dy[i];
                    if (r < 0 || r >= board.Length || c < 0 || c >= board[0].Length) continue;
                    if (board[r][c] == 'E') DFS(board, r, c);
                }
            }
        }        
    }

    private static int GetBombCount(char[][] board, int x, int y)
    {
        int count = 0;
        for (int i = 0; i < 8; i++)
        {
            x = x + dx[i];
            y = y + dy[i];
            if (x < 0 || y < 0 || x >= board.Length || y >= board[0].Length) continue;
            count += board[x][y] == 'M' || board[x][y] == 'X' ? 1 : 0;
        }

        return count;
    }
}