namespace Parkings.API.Dto;


// todo: add details
public class ParkingLotDto
{
    public required string Id { get; set; }
    public required DateTime DateCreated { get; set; }
    public required DateTime DateUpdated { get; set; }
    public required string Name { get; set; }
    public required string OwnerId { get; set; }
}
