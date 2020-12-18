// https://leetcode.com/problems/snakes-and-ladders/

using System;
using System.Collections.Generic;

public class SnakeNLadderLeet
{
    public static int Run(int[][] board)
    {
        int N = board.Length;

        // {starting pos => steps}
        var dist = new Dictionary<int,int>(); 
        dist.Add(1, 0);

        var queue = new Queue<int>();
        queue.Enqueue(1);

        while (queue.Count > 0) {
          int s = queue.Dequeue();
          if (s == N * N) return dist[s];

          for (int s2 = s + 1; s2 <= Math.Min(s + 6, N * N); s2++) {
            int rc = get(s2, N);
            int r = rc / N;
            int c = rc % N;
            int s2Final = board[r][c] == -1 ? s2 : board[r][c];
            if (!dist.ContainsKey(s2Final)) {
              dist.Add(s2Final, dist[s] + 1);
              queue.Enqueue(s2Final);
            }
          }
        }
        return -1;
    }

    private static int get(int s, int N)
    {
        // Given a square num s, return board coordinates (r, c) as r*N + c
        int quot = (s - 1) / N;
        int rem = (s - 1) % N;
        int row = N - 1 - quot;
        int col;
        if (quot % 2 == 0)
        {
            col = rem;
        }
        else
        {
            col = N - 1 - rem;
        }
        return row * N + col;
    }
}