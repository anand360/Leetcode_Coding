public abstract class Piece: IPiece{
    public PieceColor Color { get; set; }

    public bool IsAlive { get; set; }

    public abstract bool CanMove(Board board, Spot from, Spot to);
}