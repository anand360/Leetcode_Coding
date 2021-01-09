using System;

public class King : Piece
{
    public override bool CanMove(Board board, Spot from, Spot to)
    {
        int x = Math.Abs(from.GetX() - to.GetX());
        int y = Math.Abs(from.GetY() - to.GetY());

        return x + y == 1; 
    }
}