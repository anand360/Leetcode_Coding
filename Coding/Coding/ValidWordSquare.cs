public class ValidWordSquare
{
    public static bool Run(string[] words){
        if(words == null){
            return true;
        }

        for (int i = 0; i < words.Length; i++)
        {
            for (int j = 0; j < words[i].Length; j++)
            {
                if(j >= words.Length || words[j].Length <= i || words[i][j] != words[j][i]){
                    return false;
                }
            }
        }

        return true;
    }
}