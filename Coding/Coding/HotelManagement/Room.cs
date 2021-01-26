using System;
using System.Collections.Generic;

public class Room
{
    public Guid Id { get; set; }

    public RoomType Type { get; set; }

    public RoomStatus IsAvailable { get; set; }

    public Double Price { get; set; }

    public List<RoomKey> Keys { get; set; }

    public List<HousingKeepingLog> HousingKeepingLogs { get; set; }
}