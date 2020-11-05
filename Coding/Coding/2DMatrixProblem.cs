using System;
using System.Collections.Generic;
using System.Text;

namespace Coding
{
    public class _2DMatrixProblem
    {
        // Wall(-1) and gate(-2) matrix
        public static int[,] UpdateNearLoc(int[,] mat)
        {
            mat = new int[,]{
                { 0, 0, -1, -2},
                {-2, 0, 0, 0 }
            };

            bool[,] isVisited = new bool[mat.GetLength(0), mat.GetLength(1)];

            for (int i = 0; i < mat.GetLength(0); i++)
            {
                for (int j = 0; j < mat.GetLength(1); j++)
                {
                    if (mat[i,j] == -2)
                    {
                        DFS(mat, i, j, isVisited, 0);
                    }
                }
            }

            return mat;
        }

        public static void DFS(int[,] mat, int row, int col, bool[,] isVisited, int dist)
        {
            if(!isSafe(mat, row, col, isVisited))
            {
                return;
            }

            if (mat[row, col] != -2 && mat[row, col] != 0 && mat[row, col] < dist) return;

            isVisited[row, col] = true;

            mat[row, col] = mat[row, col] != -2 ? dist : mat[row, col];

            DFS(mat, row - 1, col, isVisited, dist + 1);
            DFS(mat, row, col - 1, isVisited, dist + 1);
            DFS(mat, row, col + 1, isVisited, dist + 1);
            DFS(mat, row + 1, col, isVisited, dist + 1);

            isVisited[row, col] = false;
        }

        private static bool isSafe(int[,] mat, int row, int col, bool[,] isVisited)
        {
            if (mat == null || row <0 || row >= mat.GetLength(0) || col < 0 || col >= mat.GetLength(1) || mat[row, col] == -1 || isVisited[row, col])
            {
                return false;
            }

            return true;
        }
    }
}
