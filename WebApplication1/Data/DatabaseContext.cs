using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.Data;

public class DatabaseContext : DbContext
{
    protected DatabaseContext()
    {
    }

    public DatabaseContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<Client> Clients { get; set; }
    public DbSet<Client_Trip> Client_Trips { get; set; }
    public DbSet<Country> Countries { get; set; }
    public DbSet<Country_Trip> Country_Trips { get; set; }
    public DbSet<Trip> Trips { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Client>().HasData(new List<Client>
        {
            new Client
            {
                IdClient = 1, 
                FirstName = "John", 
                LastName = "Doe", 
                Email = "dfjfnennt@o2.com", 
                Telephone = "43254376588", 
                Pesel = "12345678901"
            },
            new Client
            {
                IdClient = 2, 
                FirstName = "Jane", 
                LastName = "Damian", 
                Email = "dkfjk@gmail.com", 
                Telephone = "4321454356453", 
                Pesel = "12345678902"
            }
        });
        
        modelBuilder.Entity<Trip>().HasData(new List<Trip>
        {
            new Trip
            {
                IdTrip = 1, 
                Name = "Trip to Paris",
                Description = "bla bla",
                DateFrom = DateTime.Parse("2022-01-01"),
                DateTo = DateTime.Parse("2022-01-15"),
                MaxPeople = 20
            },
            new Trip
            {
                IdTrip = 2, 
                Name = "Trip to London", 
                Description = "bla bla bla",
                DateFrom = DateTime.Parse("2022-02-01"),
                DateTo = DateTime.Parse("2022-02-18"),
                MaxPeople = 10
            }
        });
        modelBuilder.Entity<Country>().HasData(new List<Country>
        {
            new Country
            {
                IdCountry = 1, 
                Name = "France"
            },
            new Country
            {
                IdCountry = 2, 
                Name = "United Kingdom"
            }
        });
        modelBuilder.Entity<Client_Trip>().HasData(new List<Client_Trip>
        {
            new Client_Trip
            {
                IdClient = 1, 
                IdTrip = 1, 
                RegisteredAt = 6546543, 
                PaymentDate = DateTime.Parse("2021-09-01")
            },
            new Client_Trip
            {
                IdClient = 2, 
                IdTrip = 2, 
                RegisteredAt = 543675432, 
                PaymentDate = DateTime.Parse("2021-08-01")
            }
        });
        modelBuilder.Entity<Country_Trip>().HasData(new List<Country_Trip>
        {
            new Country_Trip
            {
                IdCountry = 1, 
                IdTrip = 1
            },
            new Country_Trip
            {
                IdCountry = 2, 
                IdTrip = 2
            }
        });
    }
}