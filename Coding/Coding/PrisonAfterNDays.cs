/*
There are 8 prison cells in a row, and each cell is either occupied or vacant.

Each day, whether the cell is occupied or vacant changes according to the following rules:

If a cell has two adjacent neighbors that are both occupied or both vacant, then the cell becomes occupied.
Otherwise, it becomes vacant.
(Note that because the prison is a row, the first and the last cells in the row can't have two adjacent neighbors.)

We describe the current state of the prison in the following way: cells[i] == 1 if the i-th cell is occupied, else cells[i] == 0.

Given the initial state of the prison, return the state of the prison after N days (and N such changes described above.)
*/
// Hint: Well, the length of the loop can be 1, 7, or 14. So once we enter the loop, every 14 steps must be the same state. 
// The length of cells is even, so for any state, we can find a previous state. So all states are in a loop.

public class PrisonAfterNDays
{
    public static int[] Run(int[] cells, int N)
    {
        if (cells == null || cells.Length == 0)
        {
            return cells;
        }

        N = (N - 1) % 14 + 1;
        for (int j = 0; j < N; j++)
        {
            cells = NextState(cells);
        }

        return cells;
    }

     private static int[] NextState(int[] cells){
        var res = new int[cells.Length];
        for (int i = 1; i < cells.Length - 1; i++)
        {
            if (cells[i - 1] == cells[i + 1])
            {
                res[i] = 1;
            }
            else
            {
                res[i] = 0;
            }
        }

        return res;
    }
}