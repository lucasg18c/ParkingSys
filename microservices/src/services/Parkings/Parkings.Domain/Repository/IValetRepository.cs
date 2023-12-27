using Parkings.Domain.Models;

namespace Parkings.Domain.Repository;

public interface IValetRepository
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="valetId"></param>
    /// <returns></returns>
    Task<ICollection<ParkingMembership>> GetInvites(string valetId);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="valetId"></param>
    /// <returns></returns>
    Task<ParkingMembership?> GetCurrentMembership(string valetId);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="valetId"></param>
    /// <param name="statuses"></param>
    /// <returns></returns>
    Task<ICollection<ParkingMembership>> GetMembershipsByState(
        string valetId,
        ParkingMembershipStatus[] statuses);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="inviteId"></param>
    /// <param name="accepted"></param>
    /// <returns></returns>
    Task<ParkingMembership?> ProcessInvite(string inviteId, bool accepted);
}

