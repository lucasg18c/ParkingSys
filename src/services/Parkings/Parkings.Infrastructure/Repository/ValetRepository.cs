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

    public Task<ParkingMembership?> GetCurrentMembership(string valetId)
    {
        throw new NotImplementedException();
    }

    public Task<ICollection<ParkingMembership>> GetInvites(string valetId)
    {
        throw new NotImplementedException();
    }

    public Task<ICollection<ParkingMembership>> GetMembershipsByState(string valetId, ParkingMembershipStatus[] statuses)
    {
        throw new NotImplementedException();
    }
}
