// https://leetcode.com/discuss/interview-question/400968/Google-or-Phone-Screen-or-Valid-Date-Permutation
using System.Collections.Generic;

public class CheckValidDate
{
    public static bool res { get; set; }

    public static bool Run(List<int> input){
        if (input.Count != 3)
        {
            return false;
        }

        res = false;
        Permutate(input, 0, input.Count-1);

        return res;
    }

    private static void Permutate(List<int> input, int l, int r)
    {
        if (l == r)
        {
            res = res || CheckDate(input);
        }
        else{
            for (int i = l; i < input.Count; i++)
            {
                input = Swap(input, l, i);
                Permutate(input, l+1, r);
                input = Swap(input, l, i);
            }
        }
    }

    private static bool CheckDate(List<int> input)
    {
        var dictA = new Dictionary<int, int>{
            {4,30},
            {6, 30},
            {9, 30},
            {11, 30}
        };

        var dictB = new Dictionary<int, int>{
            {1,31},
            {3, 31},
            {5, 31},
            {7, 31},
            {8,31},
            {10,31},
            {12,31}
        };

        if(input[0] % 4 == 0 && input[1] == 2 && input[2] <= 29){
            return true;
        }
        else if(input[1] == 2 && input[2] <= 28){
            return true;
        }
        else if(dictA.ContainsKey(input[1]) && input[2] <= dictA[input[1]]){
            return true;
        }
        else if(dictB.ContainsKey(input[1]) && input[2] <= dictB[input[1]]){
            return true;
        }
        else{
            return false;
        }
    }

    private static List<int> Swap(List<int> input, int l, int i)
    {
        var temp = input[l];
        input[l] = input[i];
        input[i] = temp;

        return input;
    }
}