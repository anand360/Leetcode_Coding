using System;
using System.Collections.Generic;

public class Hotel{
    public string Name { get; set; }

    public Guid Id { get; set; }

    public Location Location { get; set; }

    public HashSet<Room> Rooms { get; set; }
}