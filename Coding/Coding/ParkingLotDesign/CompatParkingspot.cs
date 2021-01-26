public class CompatParkingspot : ParkingSpot
{
    public override bool IsAvailable { get; set; }
    public override ParkingSpotType ParkingSpotType { get; set; }

    public CompatParkingspot()
    {
        IsAvailable = true;
        ParkingSpotType = ParkingSpotType.COMPACT;
    }
}