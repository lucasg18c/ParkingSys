namespace Parkings.Domain.Models;

public class ParkingLot : Entity
{
    public required string Name { get; set; }

    public required Owner Owner { get; set; }
    public required string OwnerId { get; set; }
    
    public ICollection<Valet> Valets { get; set; } = new List<Valet>();
}
