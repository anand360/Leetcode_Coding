public class Island{
    public static int Run(char[][] grid){
        if(grid == null){
            return 0;
        }

        var count = 0;

        for (int i = 0; i < grid.Length; i++)
        {
            for (int j = 0; j < grid[0].Length; j++)
            {
                if(grid[i][j] == '1'){
                    DFSUtil(grid, i, j);
                    ++count;
                }
            }
        }

        return count;
    }

    private static void DFSUtil(char[][] grid, int i, int j)
    {
        if(i < 0 || i >= grid.Length || j < 0 || j >= grid[0].Length || grid[i][j] != '1') return;

        grid[i][j] = '0';

        DFSUtil(grid, i-1, j);
        DFSUtil(grid, i+1, j);
        DFSUtil(grid, i, j-1);
        DFSUtil(grid, i, j+1);
    }
}