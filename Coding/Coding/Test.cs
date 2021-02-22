using System.Text;

public class TestMe{
    public static void Run(){
        var sb1 = new StringBuilder().Append("Hai");
        var sb2 = new StringBuilder().Append("Hello");
        int test = 6;

        Modify(sb1, sb2, test);
        var a = sb1;
        var b = sb2;
        var c = test; 
    }

    private static void Modify(StringBuilder sb1, StringBuilder sb2, int t){
        sb1= null;
        sb2.Append(" Test");
        t = 3;
    }

     public static bool CheckSorted(int[,] input)
    {
        bool result = true;
        for (int col = input.GetLength(1) - 2; col >= 0; col--)
        {
            for (int row = 0; row < input.GetLength(1) - col - 1; row++)
            {
                if (input[row, col] > input[row+1, col+1])
                {
                    result = false;
                    break;
                }
            }

            if(!result)
            {
                break;
            }
        }

        if (!result)
        return result;

        for (int row = 1; row < input.GetLength(0); row++)
        {
            for (int col = 0; col < input.GetLength(0) - 1; col++)
            {
                if (input[row + col, col] > input[row + col + 1, col + 1])
                {
                result = false;
                break;
                }
            }

            if (!result)
            {
                break;
            }
        }

        return result;
    }
}