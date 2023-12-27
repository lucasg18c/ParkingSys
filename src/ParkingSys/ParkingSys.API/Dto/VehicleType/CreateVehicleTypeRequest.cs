namespace ParkingSys.API.Dto.VehicleType;

public class CreateVehicleTypeRequest
{
    public required string Name { get; set; }
    public required string Icon { get; set; }
    public required double CostPerHour { get; set; }
}
