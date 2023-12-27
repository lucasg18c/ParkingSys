namespace ParkingSys.API.Model;

public class Vehicle : Entity
{
    public required string Patent { get; set; }
    public required VehicleType Type { get; set; }
}
