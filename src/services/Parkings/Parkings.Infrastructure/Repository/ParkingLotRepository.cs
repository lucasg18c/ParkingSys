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
}
