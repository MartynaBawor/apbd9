using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Models;

[PrimaryKey(nameof(IdCountry))]
public class Country
{
    public int IdCountry { get; set; }
    [MaxLength(120)]
    public string Name { get; set; }
    public ICollection<Country_Trip> CountryTrips { get; set; } = new HashSet<Country_Trip>();
}