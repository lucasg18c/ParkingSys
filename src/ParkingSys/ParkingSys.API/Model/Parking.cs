namespace ParkingSys.API.Model;

public class Parking : Entity
{
    public required string Name { get; set; }
    public int LotsCount { get; set; }
}
