using Coding;

public class ChessGame{
    public Player[] Players { get; set; }
    public Board Board { get; set; }

    public Player CurrentTurnPlayer { get; set; }

    public ChessGame()
    {
        Players = new Player[2];
        Board = new Board(Players[0], Players[1]);
    } 

    public void Play(){
        CurrentTurnPlayer = null;

        while(!Board.IsWin()){
            CurrentTurnPlayer = CurrentTurnPlayer == null || CurrentTurnPlayer.Color == PieceColor.Black ? Players[0] : Players[1];
            System.Console.WriteLine($"Player {CurrentTurnPlayer.Name} enter moves:");

            var fromSpot = Board.Spots[1,2];
            var toSpot = Board.Spots[2,2];
            var move = new Move(CurrentTurnPlayer, fromSpot, toSpot);

            var validMove = false;
            do{
                validMove = Board.MakeMove(move);
            }while(!validMove);
        }

        System.Console.WriteLine($"Winner is: {CurrentTurnPlayer.Name}");
    }
}