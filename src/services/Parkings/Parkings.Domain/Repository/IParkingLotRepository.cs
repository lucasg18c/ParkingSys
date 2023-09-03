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
    /// Send an invite to a valet to join a parking lot
    /// </summary>
    /// <param name="parkingLotId">Parking lot's id</param>
    /// <param name="valetEmail">Invited valet's email</param>
    /// <returns>Parking memebrship if the invite was successful</returns>
    Task<ParkingMembership?> InviteValet(
        string parkingLotId,
        string valetEmail);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="parkingLotId"></param>
    /// <param name="statuses"></param>
    /// <returns></returns>
    Task<ICollection<ParkingMembership>> GetMembersByState(
        string parkingLotId,
        ParkingMembershipStatus[] statuses);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="parkingLotId"></param>
    /// <param name="valetEmail"></param>
    /// <returns></returns>
    Task<bool> KickValet(string parkingLotId, string valetEmail);
}
