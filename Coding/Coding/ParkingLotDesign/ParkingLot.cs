using System.Collections.Generic;
using System.Linq;

public class ParkingLot
{
    public int Id { get; set; }

    public string Name { get; set; }

    public ParkingManager ParkingManager { get; set; }

    public ParkingLot(int id, string name, int numberOfFloors, int numberOfTerminals)
    {
        Id = id;
        Name = name;

        ParkingManager = new ParkingManager(numberOfFloors, numberOfFloors);
    }

    // Admin
    public void AddFloor(ParkingFloor floor)
    {
        ParkingManager.AddFloor(floor);
    }

    public void AddParkingSpots(int floorId, ParkingSpot parkingSpot)
    {
        ParkingManager.AddParkingSpot(floorId, parkingSpot);        
    }
}