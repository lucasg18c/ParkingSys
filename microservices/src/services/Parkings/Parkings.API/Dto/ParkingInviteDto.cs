namespace Parkings.API.Dto;

public class ParkingInviteDto
{
    public required string Id { get; set; }
    
    public required ParkingLotDto ParkingLot { get; set; }
    
    public DateTime DateCreated { get; set; }
}
