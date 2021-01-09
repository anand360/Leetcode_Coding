public class Move{
    public Player Player { get; set; }
    public Spot From { get; set; }
    public Spot To { get; set; }

    public Move(Player player, Spot from, Spot to)
    {
        this.Player = player;
        this.From = from;
        this.To = to;
    }
}