using Microsoft.EntityFrameworkCore;
using Parkings.Domain.Models;
using Parkings.Domain.Repository;

namespace Parkings.Infrastructure.Repository;

/// <summary>
/// Implementation of the parking lot functionality using entity framework
/// </summary>
public class ParkingLotRepository : IParkingLotRepository
{
    private readonly ParkingsDbContext db;
    public ParkingLotRepository(ParkingsDbContext dbContext)
    {
        db = dbContext;
    }

    /// <inheritdoc/>
    public async Task<ParkingLot> Create(string ownerId, string name)
    {
        var created = new ParkingLot
        {
            Name = name,
            OwnerId = ownerId
        };

        db.ParkingLots.Add(created);
        await db.SaveChangesAsync();

        return created;
    }

    public Task<ParkingLot> Delete(string parkingLotId)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc/>
    public async Task<ICollection<ParkingLot>> GetAll()
    {
        return await db.ParkingLots.Where(p => p.DateDeleted == null).ToListAsync();
    }

    /// <inheritdoc/>
    public Task<ParkingLot?> GetById(string id)
    {
        return db.ParkingLots.FirstOrDefaultAsync(p => p.Id == id && p.DateDeleted == null);
    }

    public Task<ICollection<ParkingMembership>> GetMembersByState(string parkingLotId, ParkingMembershipStatus[] statuses)
    {
        throw new NotImplementedException();
    }

    public Task<ParkingMembership?> InviteValet(string parkingLotId, string valetEmail)
    {
        throw new NotImplementedException();
    }

    public Task<bool> KickValet(string parkingLotId, string valetEmail)
    {
        throw new NotImplementedException();
    }

    public Task<bool> Update(ParkingLot parkingLot)
    {
        throw new NotImplementedException();
    }
}
