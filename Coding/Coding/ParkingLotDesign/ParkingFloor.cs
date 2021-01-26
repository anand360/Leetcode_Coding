using System;
using System.Collections.Generic;

public class ParkingFloor
{
    public int Id { get; set; }

    public string Name { get; set; }

    public List<ParkingSpot> ParkingSpots { get; set; }

    public ParkingFloor(int id, string name)
    {
        Id = id;
        Name = name;
        ParkingSpots = new List<ParkingSpot>();
    }

    public void AddParkingSpot(ParkingSpot parkingSpot){
        ParkingSpots.Add(parkingSpot);
    }

    public List<ParkingSpot> GetParkingSpots(){
        return ParkingSpots;
    }
}