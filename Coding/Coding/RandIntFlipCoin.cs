using System;

public class RandIntFlipCoin
{
    public static int Run(int start, int end){
        if(start == end){
            return start;
        }

        var randNum = 0;
        var rand = new Random();
        for (int i = 0; i < end*end; i++)
        {
            randNum += rand.Next(0,2);
        }

        return randNum % 8;
    }
}