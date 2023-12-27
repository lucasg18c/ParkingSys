namespace Parkings.Domain.Models;

public enum ParkingMembershipStatus
{
    /// <summary>
    /// Invite pending to be reviwed
    /// </summary>
    Invited,

    /// <summary>
    /// Valet rejected the invite
    /// </summary>
    Rejected,

    /// <summary>
    /// The Valet accepted the invite, and is now a member of the parking lot
    /// </summary>
    Accepted,

    /// <summary>
    /// The Owner kicked the Valet from the parking lot
    /// </summary>
    Kicked,

    /// <summary>
    /// The valet left the parking lot
    /// </summary>
    Quitted
}