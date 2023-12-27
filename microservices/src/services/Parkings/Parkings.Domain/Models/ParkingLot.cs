namespace Parkings.Domain.Models;

public class ParkingLot : Entity
{
    public required string Name { get; set; }

    public Owner Owner { get; set; } = default!;
    public string OwnerId { get; set; } = default!;
    
    public ICollection<Valet> Valets { get; set; } = new List<Valet>();
}
