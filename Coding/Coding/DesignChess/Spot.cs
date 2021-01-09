public class Spot{
    private int X { get; set; }

    private int Y { get; set; }

    private Piece Piece { get; set; }

    public Spot(int x, int y, Piece piece)
    {
        this.X = x;
        this.Y = y;
        this.Piece = piece;
    }

    public int GetX(){
        return X;
    }

    public int GetY(){
        return Y;
    }

    public Piece GetPiece(){
        return Piece;
    }

    public void Update(Piece piece){
        this.Piece = piece;
    }
}