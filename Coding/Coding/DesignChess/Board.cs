public class Board
{
    public Spot[,] Spots { get; set; }

    public bool HaveWinner { get; private set; }

    public Player Winner { get; private set; }

    public Player[] Players { get; set; }

    public Board(Player first, Player second)
    {
        Spots = new Spot[8, 8];
        Players = new Player[2];
        Players[0] = first;
        Players[1] = second;

        Init();
    }

    public bool MakeMove(Move move)
    {
        if (move == null)
        {
            return false;
        }

        var player = move.Player;
        var from = move.From;
        var to = move.To;

        var toFromBoard = Spots[to.GetX(), to.GetY()];

        if (toFromBoard.GetPiece() != null && toFromBoard.GetPiece().Color == player.Color)
        {
            return false;
        }

        // Valid move
        if (!from.GetPiece().CanMove(this, from, to))
        {
            return false;
        }

        // Killing
        var dest = toFromBoard.GetPiece();
        if (dest != null)
        {
            dest.IsAlive = false;
        }

        toFromBoard.Update(from.GetPiece());
        from.Update(null);

        if(dest != null && dest is King){
            Winner = player;
            HaveWinner = true;
        }

        return true;
    }

    public bool IsWin()
    {
        return HaveWinner;
    }

    public Player GetWinner()
    {
        return Winner;
    }

    private void Init()
    {
        for (int i = 0; i < Players.Length; i++)
        {
            var player = Players[i];
            if (player.Color == PieceColor.White)
            {
                for (int j = 0; j < Spots.GetLength(1); j++)
                {
                    Spots[1, i] = new Spot(1, i, new Pawn());
                }

                Spots[0, 0] = new Spot(0, 0, new Rook());
                Spots[0, 7] = new Spot(0, 7, new Rook());
                Spots[0, 1] = new Spot(0, 1, new Knight());
                Spots[0, 6] = new Spot(0, 6, new Knight());
                Spots[0, 2] = new Spot(0, 2, new Bishop());
                Spots[0, 5] = new Spot(0, 5, new Bishop());
                Spots[0, 3] = new Spot(0, 3, new Queen());
                Spots[0, 4] = new Spot(0, 4, new King());
            }

            if (player.Color == PieceColor.Black)
            {
                for (int j = 0; j < Spots.GetLength(1); j++)
                {
                    Spots[6, i] = new Spot(6, i, new Pawn());
                }

                Spots[7, 0] = new Spot(7, 0, new Rook());
                Spots[7, 7] = new Spot(7, 7, new Rook());
                Spots[7, 1] = new Spot(7, 1, new Knight());
                Spots[7, 6] = new Spot(7, 6, new Knight());
                Spots[7, 2] = new Spot(7, 2, new Bishop());
                Spots[7, 5] = new Spot(7, 5, new Bishop());
                Spots[7, 3] = new Spot(7, 3, new Queen());
                Spots[7, 4] = new Spot(7, 4, new King());
            }
        }
    }
}