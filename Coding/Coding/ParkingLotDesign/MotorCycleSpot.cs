public class MotorCycleSpot : ParkingSpot
{
    public override bool IsAvailable { get; set; }
    public override ParkingSpotType ParkingSpotType { get; set; }

    public MotorCycleSpot()
    {
        IsAvailable = true;
        ParkingSpotType = ParkingSpotType.MOTORCYCLE;
    }
}