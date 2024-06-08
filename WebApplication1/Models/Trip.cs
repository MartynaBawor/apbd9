using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Models;

[PrimaryKey(nameof(IdTrip))]
public class Trip
{
    public int IdTrip { get; set; }
    [MaxLength(120)]
    public string Name { get; set; }
    [MaxLength(220)]
    public string Description { get; set; }
    public DateTime DateFrom { get; set; }
    public DateTime DateTo { get; set; }
    public int MaxPeople { get; set; }
    public ICollection<Country_Trip> CountryTrips { get; set; } = new HashSet<Country_Trip>();
    public ICollection<Client_Trip> ClientTrips { get; set; } = new HashSet<Client_Trip>();
}