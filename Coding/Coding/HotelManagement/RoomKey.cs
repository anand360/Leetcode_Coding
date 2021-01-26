using System;

public class RoomKey
{
    public Guid Id { get; set; }

    public string Barcode { get; set; }

    public DateTime IssuedOn { get; set; }

    public bool IsActive { get; set; }

    public bool IsMaster { get; set; }

    public void AddRoom(Room room){
        
    }
}