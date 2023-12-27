namespace ParkingSys.API.Model;

public class VehicleType : Entity
{
    public required string Name { get; set; }
    public required string Icon { get; set; }
    public required double CostPerHour { get; set; }
}
