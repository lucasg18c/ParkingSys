namespace Parkings.Domain.Models;

public abstract class User : Entity
{
    public required string Uid { get; set; }
    public required string Name { get; set; }
    public required string LastName { get; set; }
    public required string Email { get; set; }
    public required AuthProvider Provider { get; set; } = AuthProvider.Google;

    public string? ParkingLotId { get; set; }
    public ParkingLot? ParkingLot { get; set; }
}
