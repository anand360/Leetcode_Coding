public interface IParkingAssignmentStrategy
{
    public ParkingSpot GetParkingSpot(Terminal terminalId);

    public void ReleaseParkingSpot(ParkingTicket parkingTicket);
}