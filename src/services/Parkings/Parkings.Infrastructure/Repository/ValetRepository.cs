using Microsoft.EntityFrameworkCore;
using Parkings.Domain.Models;
using Parkings.Domain.Repository;

namespace Parkings.Infrastructure.Repository;

public class ValetRepository : IValetRepository
{
    private readonly ParkingsDbContext db;
    public ValetRepository(ParkingsDbContext dbContext)
    {
        db = dbContext;
    }

    /// <inheritdoc/>
    public Task<ParkingMembership?> GetCurrentMembership(string valetId)
    {
        return db.ParkingMemberships
            .FirstOrDefaultAsync(m => m.Valet.Id == valetId && m.Status == ParkingMembershipStatus.Accepted);
    }

    /// <inheritdoc/>
    public Task<ICollection<ParkingMembership>> GetInvites(string valetId)
    {
        return GetMembershipsByState(valetId, new ParkingMembershipStatus[] { ParkingMembershipStatus.Invited });
    }

    /// <inheritdoc/>
    public async Task<ICollection<ParkingMembership>> GetMembershipsByState(
        string valetId,
        ParkingMembershipStatus[] statuses)
    {
        return await db.ParkingMemberships
            .Where(m => m.Valet.Id == valetId && statuses.Contains(m.Status))
            .Include(m => m.Valet)
            .Include(m => m.ParkingLot)
            .ToListAsync();
    }

    /// <inheritdoc/>
    public async Task<ParkingMembership?> ProcessInvite(string inviteId, bool accepted)
    {
        var invite = await db.ParkingMemberships.FirstOrDefaultAsync(i => i.Id == inviteId);

        if (invite is null)
        {
            return null;
        }

        invite.Status = accepted ? ParkingMembershipStatus.Accepted : ParkingMembershipStatus.Rejected;
        invite.DateUpdated = DateTime.UtcNow;

        await db.SaveChangesAsync();

        return invite;
    }
}
