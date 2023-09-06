using Parkings.Domain.Models;

namespace Parkings.Domain.Repository;

/// <summary>
/// Abstraction of the parking lot functionality
/// </summary>
public interface IParkingLotRepository
{
    /// <summary>
    /// Gets all parking lots.
    /// </summary>
    /// <returns></returns>
    Task<ICollection<ParkingLot>> GetAll();

    /// <summary>
    /// Gets a parking lot by its id.
    /// </summary>
    /// <param name="id">Parking's id</param>
    /// <returns></returns>
    Task<ParkingLot?> GetById(string id);

    /// <summary>
    /// Creates a parking lot with a name and a previouly created owner's id.
    /// </summary>
    /// <param name="ownerId">Id of the parking's owner</param>
    /// <param name="name">Name of the parking lot</param>
    /// <returns></returns>
    Task<ParkingLot> Create(string ownerId, string name);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="parkingLot"></param>
    /// <returns></returns>
    Task<bool> Update(ParkingLot parkingLot);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="parkingLotId"></param>
    /// <returns></returns>
    Task<ParkingLot> Delete(string parkingLotId);

    /// <summary>
    /// Invites a valet to a parking lot by their email address.
    /// </summary>
    /// <param name="parkingLotId">The ID of the parking lot to which the valet is invited.</param>
    /// <param name="valetEmail">The email address of the valet to invite.</param>
    /// <returns>
    /// A task that represents the asynchronous operation. Returns a <see cref="ParkingMembership"/> object
    /// representing the invitation if successful, or null if the valet was already invited, the valet or parking lot doesn't exist.
    /// </returns>
    Task<ParkingMembership?> InviteValet(
        string parkingLotId,
        string valetEmail);

    /// <summary>
    /// Retrieves a collection of parking memberships based on the specified parking lot ID and membership statuses.
    /// </summary>
    /// <param name="parkingLotId">The ID of the parking lot to filter memberships.</param>
    /// <param name="statuses">An array of parking membership statuses to filter by.</param>
    /// <returns>A task that represents the asynchronous operation, returning a collection of parking memberships matching the criteria.</returns>
    Task<ICollection<ParkingMembership>> GetMembersByState(
        string parkingLotId,
        ParkingMembershipStatus[] statuses);

    /// <summary>
    /// Retrieves a collection of Valets that are currently employees of the parking lot.
    /// </summary>
    /// <param name="parkingLotId">The ID of the parking lot to filter memberships.</param>
    /// <returns></returns>
    Task<ICollection<Valet>> GetCurrentMembers(string parkingLotId);

    /// <summary>
    /// Kicks a valet from a parking lot by their email address.
    /// </summary>
    /// <param name="parkingLotId">The ID of the parking lot from which the valet is kicked.</param>
    /// <param name="valetEmail">The email address of the valet to kick.</param>
    /// <returns>
    /// A task that represents the asynchronous operation. Returns true if the valet was successfully kicked,
    /// or false if the valet was not found.
    /// </returns>
    Task<bool> KickValet(string parkingLotId, string valetEmail);
}
