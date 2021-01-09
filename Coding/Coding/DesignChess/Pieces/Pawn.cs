public class Pawn : Piece
{
    public override bool CanMove(Board board, Spot from, Spot to)
    {
        return to.GetX() == from.GetX() && to.GetY() - from.GetY() == 1;
    }
}