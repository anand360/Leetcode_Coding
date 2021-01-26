public class HandicappedParkingSpot: ParkingSpot
{
    public override bool IsAvailable { get; set; }
    public override ParkingSpotType ParkingSpotType { get; set; }

    public HandicappedParkingSpot()
    {
        IsAvailable = true;
        ParkingSpotType = ParkingSpotType.HANDICAPPED;
    }
}