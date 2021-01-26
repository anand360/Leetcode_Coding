public class LargeParkingSpot: ParkingSpot
{
    public override bool IsAvailable { get; set; }
    public override ParkingSpotType ParkingSpotType { get; set; }

    public LargeParkingSpot()
    {
        IsAvailable = true;
        ParkingSpotType = ParkingSpotType.LARGE;
    }
}