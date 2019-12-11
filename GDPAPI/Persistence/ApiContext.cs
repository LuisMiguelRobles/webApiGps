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
        public DbSet<Driver> Drivers { get; set; }
        public DbSet<Station> Destinations { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<Seat> Seats { get; set; }
        public DbSet<DestinationOffered> DestinationsOffered { get; set; }
        public DbSet<VehicleDeparture> VehicleDepartures { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            /*Users*/
            modelBuilder.Entity<User>().HasKey(user => new { user.Id });
            modelBuilder.Entity<User>().Property(user => user.Name).IsRequired();
            modelBuilder.Entity<User>().Property(user => user.LastName).IsRequired();
            modelBuilder.Entity<User>().Property(user => user.Password).IsRequired();
            modelBuilder.Entity<User>().Property(user => user.UserType).IsRequired();
            modelBuilder.Entity<User>().Property(user => user.Email).IsRequired();
            modelBuilder.Entity<User>().HasIndex(user => user.Email).IsUnique();
            modelBuilder.Entity<User>().Property(user => user.City).IsRequired();
            modelBuilder.Entity<User>().Property(user => user.Phone).IsRequired();


            /*Driver*/
            modelBuilder.Entity<Driver>().HasKey(driver => new { driver.Identification });
            modelBuilder.Entity<Driver>().Property(driver => driver.Name).IsRequired();
            modelBuilder.Entity<Driver>().Property(driver => driver.Phone).IsRequired();
            modelBuilder.Entity<Driver>()
                .HasOne(driver => driver.Vehicle)
                .WithOne(vehicle => vehicle.Driver)
                .HasForeignKey<Driver>(driver => driver.VehicleIdentification);



            /*Station*/
            modelBuilder.Entity<Station>().HasKey(destination => new { destination.Id });
            modelBuilder.Entity<Station>().Property(destination => destination.Name).IsRequired();
            modelBuilder.Entity<Station>().Property(destination => destination.Code).IsRequired();

            /*Company*/
            modelBuilder.Entity<Company>().HasKey(company => new { company.Nit });
            modelBuilder.Entity<Company>().Property(company => company.Name).IsRequired();
            modelBuilder.Entity<Company>().Property(company => company.Phone).IsRequired();
            modelBuilder.Entity<Company>().HasIndex(company => company.Email).IsUnique();
            modelBuilder.Entity<Company>().Property(company => company.Email).IsRequired();

            /*Vehicle*/
            modelBuilder.Entity<Vehicle>().HasKey(vehicle => new { vehicle.Plaque });
            modelBuilder.Entity<Vehicle>().Property(vehicle => vehicle.InternalIdentifier).IsRequired();
            modelBuilder.Entity<Vehicle>()
                .HasOne(company => company.Company)
                .WithMany(vehicle => vehicle.Vehicle)
                .HasForeignKey(company => company.CompanyNit);

            modelBuilder.Entity<Vehicle>()
                .HasOne(vehicle => vehicle.Driver)
                .WithOne(driver => driver.Vehicle)
                .HasForeignKey<Driver>(driver => driver.VehicleIdentification);

            /*Seat*/
            modelBuilder.Entity<Seat>().HasKey(seat => new { seat.Id });
            modelBuilder.Entity<Seat>().Property(seat => seat.SeatNumber).IsRequired();
            modelBuilder.Entity<Seat>()
                .HasOne(seat => seat.Vehicle)
                .WithMany(vehicle => vehicle.Seats)
                .HasForeignKey(vehicle => vehicle.VehiclePlaque);

            /**/
            modelBuilder.Entity<DestinationOffered>().HasKey(dOffered => new { dOffered.Id });
            modelBuilder.Entity<DestinationOffered>().Property(dOffered => dOffered.DestinationPrice).IsRequired();
            modelBuilder.Entity<DestinationOffered>().Property(dOffered => dOffered.Direct).IsRequired();
            modelBuilder.Entity<DestinationOffered>().HasOne(dOffered => dOffered.Station)
                .WithMany(dest => dest.DestinationOffers)
                .HasForeignKey(dOffered => dOffered.DestinationId);

            modelBuilder.Entity<DestinationOffered>().HasOne(dOffered => dOffered.Company)
                .WithMany(dest => dest.DestinationOffers)
                .HasForeignKey(dOffered => dOffered.CompanyNit);

            modelBuilder.Entity<VehicleDeparture>().HasKey(vDeparture => new { vDeparture.Id });
            modelBuilder.Entity<VehicleDeparture>().Property(vDeparture => vDeparture.DateTime).IsRequired();

            /*ticket*/
            modelBuilder.Entity<Ticket>().HasKey(ticket => new { ticket.Id });
            modelBuilder.Entity<Ticket>().Property(ticket => ticket.SeatNumber).IsRequired();
            modelBuilder.Entity<Ticket>().Property(ticket => ticket.Status).IsRequired();
            modelBuilder.Entity<Ticket>().Property(ticket => ticket.TicketPrice).IsRequired();
        }
    }
}
