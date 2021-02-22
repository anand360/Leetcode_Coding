using System;
using System.Collections.Generic;
using System.Text;

public class NQueen
{
    public static IList<IList<string>> SolveNQueen(int n){
        if (n == 0)
        {
            return null;
        }

        var mat = new char[n,n];
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                mat[i,j] = '.';
            }
        }
        IList<IList<string>> res = new List<IList<string>>();
        SolveNQueenUtil(mat, 0, res);

        return res;
    }

    private static bool SolveNQueenUtil(char[,] mat, int col, IList<IList<string>> result)
    {
        if(col == mat.GetLength(1)){
            result.Add(PrintSolution(mat));
            return true;
        }

        bool res = false;
        for (int i = 0; i < mat.GetLength(0); i++)
        {
            if(IsSafe(mat, i, col)){
                mat[i,col] = 'Q';

                res = SolveNQueenUtil(mat, col+1, result) || res;

                mat[i,col] = '.';
            }
        }

        return res;
    }

    private static bool IsSafe(char[,] mat, int row, int col)
    {
        for (int i = 0; i < col; i++)
        {
            if(mat[row, i] == 'Q')
            return false;
        }

        int r = row;
        int c = col;
        for (; r >=0 && c >= 0; r--, c--)
        {
            if(mat[r, c] == 'Q')
            return false;
        }

        r = row;
        c = col;

        for (; r < mat.GetLength(0) && c >= 0; r++, c--)
        {
            if(mat[r, c] == 'Q')
            return false;
        }

        return true;
    }

    private static List<string> PrintSolution(char[,] mat)
    {
        var res = new List<string>();
        for (int i = 0; i < mat.GetLength(0); i++)
        {
            var output = new StringBuilder();
            for (int j = 0; j < mat.GetLength(1); j++)
            {
                output.Append(mat[i,j]);
            }

            res.Add(output.ToString());
        }

        return res;
    }

}