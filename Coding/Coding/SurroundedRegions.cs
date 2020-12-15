using System;
using System.Collections.Generic;

public class SurroundedRegions
{
    public static void Run(char[][] board)
    {
        if (board == null || board.Length == 0 || board.Length == 1 || board[0] == null || board[0].Length == 1)
        {
            return;
        }

        // Row- 0th and last
        for (int i = 0; i < board[0].Length; i++)
        {
            if (board[0][i] == 'O')
                DFSUtil(board, 0, i);

            if (board[board.Length-1][i] == 'O')
                DFSUtil(board, board.Length-1, i);
        }

        // col- 0th and last
        for (int i = 1; i < board.Length-1; i++)
        {
            if (board[i][0] == 'O')
                DFSUtil(board, i, 0);

            if (board[i][board[0].Length-1] == 'O')
                DFSUtil(board, i, board[0].Length-1);
        }

        for (int i = 0; i < board.Length; i++)
        {
            for (int j = 0; j < board[0].Length; j++)
            {
                if(board[i][j] == '*') board[i][j] = 'O';
                else if(board[i][j] == 'O') board[i][j] = 'X';
            }
        }

        for (int i = 0; i < board.Length; i++)
        {
            for (int j = 0; j < board[0].Length; j++)
            {
                System.Console.Write(board[i][j]);
                System.Console.Write(" ");
            }
            System.Console.WriteLine();
        }
    }

    private static void DFSUtil(char[][] board, int i, int j)
    {
        if (i < 0 || i > board.Length - 1 || j < 0 || j > board[0].Length - 1 || board[i][j] != 'O')
            return;

        board[i][j] = '*';

        DFSUtil(board, i + 1, j);
        DFSUtil(board, i - 1, j);
        DFSUtil(board, i, j + 1);
        DFSUtil(board, i, j - 1);
    }

    private static void BFSUtil(char[][] board, int i, int j){
        //if(board[i][j] == '*') return;

        var queue = new Queue<Tuple<int,int>>();
        var t = new Tuple<int,int>(i,j);

        queue.Enqueue(t);

        while (queue.Count > 0)
        {
            var item = queue.Dequeue();

            i = item.Item1;
            j = item.Item2;

            if (i >= 0 && i < board.Length && j >= 0 && j < board[0].Length && board[i][j] == 'O'){
                board[i][j] = '*';
                queue.Enqueue(new Tuple<int,int>(i+1,j));
                queue.Enqueue(new Tuple<int,int>(i-1,j));
                queue.Enqueue(new Tuple<int,int>(i,j+1));
                queue.Enqueue(new Tuple<int,int>(i,j-1));
            }            
        }
    }
}