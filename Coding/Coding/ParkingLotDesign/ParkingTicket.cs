using System;

public class ParkingTicket
{
    public Guid Id { get; set; }

    public ParkingSpot parkingSpot { get; set; }

    public DateTime EntryTime { get; set; }

    public DateTime ExitTime { get; set; }
}