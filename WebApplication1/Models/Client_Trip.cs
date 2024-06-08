using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Models;

[PrimaryKey(nameof(IdClient), nameof(IdTrip))]
public class Client_Trip
{
    public int IdClient { get; set; }
    public int IdTrip { get; set; }
    public int RegisteredAt { get; set; }
    public DateTime? PaymentDate { get; set; }
    [ForeignKey(nameof(IdClient))]
    public Client Client { get; set; }
    [ForeignKey(nameof(IdTrip))]
    public Trip Trip { get; set; }
}