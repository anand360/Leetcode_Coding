using System;

public class Queen : Piece
{
    public override bool CanMove(Board board, Spot from, Spot to)
    {
        return (Math.Abs(to.GetX() - from.GetX()) == Math.Abs(to.GetY() - from.GetY()))
               || 
               to.GetX() == from.GetX() || to.GetY() == from.GetY();
    }
}