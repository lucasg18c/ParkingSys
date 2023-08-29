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
}
