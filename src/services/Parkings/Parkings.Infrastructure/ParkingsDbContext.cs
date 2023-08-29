using Microsoft.EntityFrameworkCore;
using Parkings.Domain.Models;

namespace Parkings.Infrastructure;

public class ParkingsDbContext : DbContext
{
    public ParkingsDbContext(DbContextOptions options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>().ToTable("Users");

        modelBuilder.Entity<ParkingLot>()
            .HasOne(p => p.Owner)
            .WithOne(u => u.ParkingLot)
            .HasForeignKey<ParkingLot>(p => p.OwnerId);

        modelBuilder.Entity<ParkingLot>()
            .HasMany(p => p.Valets)
            .WithOne(u => u.ParkingLot)
            .HasForeignKey(v => v.ParkingLotId);
    }

    public DbSet<Valet> Valets { get; set; }
    public DbSet<Owner> Owners { get; set; }
    public DbSet<ParkingLot> ParkingLots { get; set; }
}
