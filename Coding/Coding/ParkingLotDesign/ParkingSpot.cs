public abstract class ParkingSpot
{
    public int Id { get; set; }

    public string VehicleLicenseNumber { get; set; }

    public abstract bool IsAvailable { get; set; }

    public abstract ParkingSpotType ParkingSpotType { get; set; }

    // floornumber|SpotNumber
    public string Location { get; set; }

    public void Park(string vehicleLicenseNumber){
        if(IsAvailable){
            this.VehicleLicenseNumber = vehicleLicenseNumber;
            IsAvailable = false;
        }
    }
}