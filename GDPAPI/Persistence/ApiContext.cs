using GDPAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace GDPAPI.Persistence.Context
{
    public class ApiContext : DbContext
    {
        public ApiContext(DbContextOptions options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Driver> Drivers { get; set; }
        public DbSet<Destination> Destinations { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<Seat> Seats { get; set; }
        public DbSet<DestinationOffered> DestinationsOffered { get; set; }
        public DbSet<VehicleDeparture> VehicleDepartures { get; set; }
        public DbSet<SeatOcupation> SeatsOcupation { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<User>().HasKey(user => new { user.Id });
            modelBuilder.Entity<User>().Property(user => user.Name).IsRequired();
            modelBuilder.Entity<User>().Property(user => user.LastName).IsRequired();
            modelBuilder.Entity<User>().Property(user => user.Email).IsRequired();
            modelBuilder.Entity<User>().HasIndex(user => user.Email).IsUnique();
            modelBuilder.Entity<User>().Property(user => user.Password).IsRequired();

            modelBuilder.Entity<Client>().HasKey(client => new { client.Identification });
            modelBuilder.Entity<Client>().Property(client => client.Name).IsRequired();
            modelBuilder.Entity<Client>().Property(client => client.Celphone).IsRequired();
            modelBuilder.Entity<Client>().Property(client => client.Email).IsRequired();
            modelBuilder.Entity<Client>().HasIndex(client => client.Email).IsUnique();
            modelBuilder.Entity<Client>().Property(client => client.Username).IsRequired();
            modelBuilder.Entity<Client>().Property(client => client.Password).IsRequired();

            modelBuilder.Entity<Driver>().HasKey(driver => new { driver.Identification });
            modelBuilder.Entity<Driver>().Property(driver => driver.Name).IsRequired();
            modelBuilder.Entity<Driver>().Property(driver => driver.Celphone).IsRequired();

            modelBuilder.Entity<Destination>().HasKey(destination => new { destination.Id });
            modelBuilder.Entity<Destination>().Property(destination => destination.Location).IsRequired();

            modelBuilder.Entity<Company>().HasKey(company => new { company.Nit });
            modelBuilder.Entity<Company>().Property(company => company.Name).IsRequired();
            modelBuilder.Entity<Company>().Property(company => company.Celphone).IsRequired();
            modelBuilder.Entity<Company>().HasIndex(company => company.Email).IsUnique();
            modelBuilder.Entity<Company>().Property(company => company.Email).IsRequired();

            modelBuilder.Entity<Vehicle>().HasKey(vehicle => new { vehicle.Plaque });
            modelBuilder.Entity<Vehicle>().Property(vehicle => vehicle.InternalIdentifier).IsRequired();
            modelBuilder.Entity<Vehicle>()
                .HasOne(company => company.Company)
                .WithMany(vehicle => vehicle.Vehicle)
                .HasForeignKey(company => company.CompanyNit);


            modelBuilder.Entity<Seat>().HasKey(seat => new { seat.Id });
            modelBuilder.Entity<Seat>().Property(seat => seat.SeatNumber).IsRequired();
            modelBuilder.Entity<Seat>()
                .HasOne(seat => seat.Vehicle)
                .WithMany(vehicle => vehicle.Seats)
                .HasForeignKey(vehicle => vehicle.VehiclePlaque);


            modelBuilder.Entity<DestinationOffered>().HasKey(dOffered => new { dOffered.Id });
            modelBuilder.Entity<DestinationOffered>().Property(dOffered => dOffered.DestinationPrice).IsRequired();
            modelBuilder.Entity<DestinationOffered>().Property(dOffered => dOffered.Direct).IsRequired();
            modelBuilder.Entity<DestinationOffered>().HasOne(dOffered => dOffered.Destination)
                .WithMany(dest => dest.DestinationOffers)
                .HasForeignKey(dOffered => dOffered.DestinationID);

            modelBuilder.Entity<DestinationOffered>().HasOne(dOffered => dOffered.Company)
                .WithMany(dest => dest.DestinationOffers)
                .HasForeignKey(dOffered => dOffered.CompanyNit);

            modelBuilder.Entity<VehicleDeparture>().HasKey(vDeparture => new { vDeparture.Id });
            modelBuilder.Entity<VehicleDeparture>().Property(vDeparture => vDeparture.Date).IsRequired();

            modelBuilder.Entity<SeatOcupation>().HasKey(sOcupation => new { sOcupation.Id });
            modelBuilder.Entity<SeatOcupation>().Property(sOcupation => sOcupation.SeatNumber).IsRequired();
            modelBuilder.Entity<SeatOcupation>().Property(sOcupation => sOcupation.Status).IsRequired();
            modelBuilder.Entity<SeatOcupation>().Property(sOcupation => sOcupation.TicketPrice).IsRequired();
        }
    }
}
