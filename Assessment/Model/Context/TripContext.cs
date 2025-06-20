using Microsoft.EntityFrameworkCore;

namespace Assessment.Model.Context;

public class TripContext : DbContext
{
    public TripContext(DbContextOptions<TripContext> options) : base(options)
    {
    }

    public DbSet<City> Cities { get; set; }
    public DbSet<TouristPackage> TouristPackages { get; set; }

    public DbSet<Reservation> Reservations { get; set; }
    public DbSet<Client> Clients { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TouristPackage>().Property(t => t.Price).HasColumnType("decimal(18,2)");

        modelBuilder.Entity<Client>().HasMany(c => c.Reservations).WithOne(r => r.Client)
            .HasForeignKey(r => r.ClientId);

        modelBuilder.Entity<TouristPackage>().HasMany(t => t.Cities);

        modelBuilder.Entity<Reservation>()
            .HasIndex(r => new { r.ClientId, r.TouristPackageId, r.ReservationDate })
            .IsUnique();
    }
}