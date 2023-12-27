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
        return await db.ParkingLots.ToListAsync();
    }

    /// <inheritdoc/>
    public Task<ParkingLot?> GetById(string id)
    {
        return db.ParkingLots.FirstOrDefaultAsync(p => p.Id == id);
    }

    /// <inheritdoc/>
    public async Task<ICollection<Valet>> GetCurrentMembers(string parkingLotId)
    {
        return await db.ParkingMemberships
            .Where(p => p.ParkingLot.Id == parkingLotId && p.Status == ParkingMembershipStatus.Accepted)
            .Include(p => p.Valet)
            .Select(p => p.Valet)
            .ToListAsync();
    }

    /// <inheritdoc/>
    public async Task<ICollection<ParkingMembership>> GetMembersByState(
        string parkingLotId,
        ParkingMembershipStatus[] statuses)
    {
        return await db.ParkingMemberships
            .Where(p => p.ParkingLot.Id == parkingLotId && statuses.Contains(p.Status))
            .ToListAsync();
    }

    /// <inheritdoc/>
    public async Task<ParkingMembership?> InviteValet(string parkingLotId, string valetEmail)
    {
        var existingInvite = await GetMembership(parkingLotId, valetEmail);

        // this valet was already invited
        if (existingInvite is not null)
        {
            return null;
        }

        var valet = await db.Valets.FirstOrDefaultAsync(v => v.Email == valetEmail);

        // Valet doesn't exist
        if (valet is null)
        {
            return null;
        }

        var parking = await GetById(parkingLotId);

        // Parking doesn't exist
        if (parking is null)
        {
            return null;
        }

        var invite = new ParkingMembership
        {
            Valet = valet,
            ParkingLot = parking,
        };

        db.ParkingMemberships.Add(invite);

        await db.SaveChangesAsync();

        return invite;
    }

    /// <inheritdoc/>
    public async Task<bool> KickValet(string parkingLotId, string valetEmail)
    {
        var valetMembership = await GetMembership(parkingLotId, valetEmail);

        // Valet not found
        if (valetMembership is null)
        {
            return false;
        }

        valetMembership.Status = ParkingMembershipStatus.Kicked;
        valetMembership.DateUpdated = DateTime.UtcNow;

        await db.SaveChangesAsync();

        return true;
    }

    /// <inheritdoc/>
    public async Task<bool> Update(ParkingLot parkingLot)
    {
        var found = await GetById(parkingLot.Id);

        // Parking was not found
        if (found is null)
        {
            return false;
        }

        found.OwnerId = parkingLot.OwnerId ?? found.OwnerId;
        found.Name = parkingLot.Name ?? found.Name;
        found.DateUpdated = DateTime.UtcNow;

        await db.SaveChangesAsync();

        return true;
    }

    private Task<ParkingMembership?> GetMembership(string parkingLotId, string valetEmail)
    {
        return db.ParkingMemberships
            .FirstOrDefaultAsync(p => p.ParkingLot.Id == parkingLotId && p.Valet.Email == valetEmail);
    }
}
