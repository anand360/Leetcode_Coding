using System;
using System.Collections.Generic;

public class MileStones{
        public int Point { get; set; }
        public List<MileStones> Children { get; set; }

        public MileStones(int p)
        {
            this.Point = p;
            this.Children = new List<MileStones>();
        }

        public void AddMileStone(MileStones mileStone){
            if(Children != null){
                Children.Add(mileStone);
            }
        }
    }

public class MaxGamePoint
{
    public static int GetMaxPoints(MileStones game, List<int> res){
        if(game == null){
            return 0;
        }

        res.Add(game.Point);

        if(game.Children.Count == 0){
            PrintPath(res);
            if(res.Count > 0){
                res.RemoveAt(res.Count - 1);
            }
            
            return game.Point;
        }

        int maxPoint = 0;

        foreach (var item in game.Children)
        {
            maxPoint = Math.Max(maxPoint, GetMaxPoints(item, res));
        }

        if(res.Count > 0){
            res.RemoveAt(res.Count - 1);
        }

        return maxPoint + game.Point;
    }

    private static void PrintPath(List<int> res)
    {
        var sum = 0;
        if(res != null){
            var count = 0;
            while(count < res.Count){
                var val = res[count];
                Console.Write($"{val} -> ");
                sum += val;
                count++;
            }

            Console.Write($" = {sum}");
            Console.WriteLine();
        }
    }
}