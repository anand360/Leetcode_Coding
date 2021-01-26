using System;
using System.Collections.Generic;
using System.Linq;

public class ParkingManager
{
    public HashSet<ParkingSpot> AvailableParkingSpots { get; set; }

    public HashSet<ParkingSpot> ReservedParkingSpots { get; set; }

    public List<ParkingFloor> ParkingFloors { get; set; }

    public List<Terminal> Terminals { get; set; }

    public ParkingManager(int numberOfFloors, int numberOfTerminals)
    {
        AvailableParkingSpots = new HashSet<ParkingSpot>();
        ReservedParkingSpots = new HashSet<ParkingSpot>();

        ParkingFloors = new List<ParkingFloor>(numberOfFloors);
        Terminals = new List<Terminal>(numberOfTerminals);
    }

    // admin
    internal void AddFloor(ParkingFloor floor)
    {
        ParkingFloors.Add(floor);
    }

    internal void AddParkingSpot(int floorId, ParkingSpot parkingSpot)
    {
        var floor = ParkingFloors.Where(x => x.Id == floorId).FirstOrDefault();
        if(floor != null){
            floor.AddParkingSpot(parkingSpot);
            AvailableParkingSpots.Add(parkingSpot);
        }
    }

    internal void AddTerminal(Terminal terminal)
    {
        Terminals.Add(terminal);
    }

    internal Terminal GetTerminal(int terminalId)
    {
        return Terminals.Where(x => x.Id == terminalId).FirstOrDefault();
    }

    internal bool Park(int terminalId, string vehicleLicenseNumber, ParkingSpotType requiredParkingSpotType, IParkingAssignmentStrategy parkingAssignmentStrategy){
        var terminal = GetTerminal(terminalId);
        var parkingspot = parkingAssignmentStrategy.GetParkingSpot(terminal);

        parkingspot.Park(vehicleLicenseNumber);

        return true;
    }

    internal ParkingTicket GetParkingTicket(ParkingSpot parkingSpot)
    {
        var parkingTicket = new ParkingTicket{
            Id = Guid.NewGuid(),
            parkingSpot = parkingSpot,
            EntryTime = DateTime.UtcNow
        };

        return parkingTicket;
    }
}