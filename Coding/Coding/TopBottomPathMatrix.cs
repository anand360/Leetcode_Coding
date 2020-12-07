public class TopBottomPathMatrix
{
    public static bool Run(int[,] mat)
    {
        if (mat == null)
        {
            return true;
        }

        var visited = new bool[mat.GetLength(0), mat.GetLength(1)];
        var res = false;

        res = CheckPathUtil(mat, visited, 0, 0, res);

        return res;
    }

    private static bool CheckPathUtil(int[,] mat, bool[,] visited, int r, int c, bool res)
    {
        var xi = new int[] { -1, 1, 0, 0 };
        var xj = new int[] { 0, 0, -1, 1 };

        if (r == mat.GetLength(0) - 1 && c == mat.GetLength(1) - 1)
        {
            res = true;
            return res;
        }

        visited[r, c] = true;

        for (int i = 0; i < xi.Length; i++)
        {
            int di = r + xi[i];
            int dj = c + xj[i];

            if (IsSafe(mat, visited, di, dj) && mat[r, c] >= mat[di, dj])
            {
                res = res || CheckPathUtil(mat, visited, di, dj, res);
            }
        }

        return res;
    }

    private static bool IsSafe(int[,] mat, bool[,] visited, int di, int dj)
    {
        return di >= 0 && di < mat.GetLength(0) && dj >= 0 && dj < mat.GetLength(1) && !visited[di, dj];
    }
}