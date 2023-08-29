using Parkings.Domain.Models;

namespace Parkings.API.Dto;


public class ParkingLotForListDto
{
    public required string Id { get; set; }
    public required DateTime DateCreated { get; set; } 
    public required DateTime DateUpdated { get; set; } 
    public required string Name { get; set; }
    public required string OwnerId { get; set; }
}
