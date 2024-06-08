using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Models;

[PrimaryKey(nameof(IdClient))]
public class Client
{
    [Key]
    public int IdClient { get; set; }
    [MaxLength(120)] 
    public string FirstName { get; set; }
    [MaxLength(120)] 
    public string LastName { get; set; }
    [MaxLength(120)] 
    public string Email { get; set; }
    [MaxLength(120)] 
    public string Telephone { get; set; }
    [MaxLength(120)] 
    public string Pesel { get; set; }

    public ICollection<Client_Trip> ClientTrips { get; set; } = new HashSet<Client_Trip>();
}