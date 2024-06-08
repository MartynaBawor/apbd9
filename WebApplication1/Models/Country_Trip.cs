using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Models;

[PrimaryKey(nameof(IdCountry), nameof(IdTrip))]
public class Country_Trip
{
    public int IdCountry { get; set; }
    public int IdTrip { get; set; }
    [ForeignKey(nameof(IdCountry))]
    public Country Country { get; set; }
    [ForeignKey(nameof(IdTrip))]
    public Trip Trip { get; set; }
}