namespace Parkings.Domain.Models;

/// <summary>
/// Represents the relation between a Valet and a Parking Lot
/// </summary>
public class ParkingMembership : Entity
{
    public required Valet Valet { get; set; }

    public required ParkingLot ParkingLot { get; set; }

    public ParkingMembershipStatus Status { get; set; }
        = ParkingMembershipStatus.Invited;
}
