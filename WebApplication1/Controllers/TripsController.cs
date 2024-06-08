using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.DTOs;
using WebApplication1.Models;
using WebApplication1.Services;

namespace WebApplication1.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TripsController : ControllerBase
{
    private readonly IDbService _dbService;

    public TripsController(IDbService dbService)
    {
        _dbService = dbService;
    }

    [HttpGet]
    public async Task<IActionResult> GetTripsSorted(int page = 1, int pageSize = 10)
    {
        if (page < 1 || pageSize < 1)
        {
            return BadRequest("Page and pageSize parameters must be greater than 0");
        }
        
        var totalTripsCount = await _dbService.GetTotalTripsCount();
        var trips = await _dbService.GetTripsSorted(page, pageSize);
        return Ok(new GetTripsResponseDTO()
        {
            PageNum = page,
            PageSize = pageSize,
            AllPages = (int)Math.Ceiling((double)totalTripsCount / pageSize),
            Trips = trips.Select(e => new GetTripsDTO()
            {
                Name = e.Name,
                Description = e.Description,
                DateTo = e.DateTo,
                DateFrom = e.DateFrom,
                MaxPeople = e.MaxPeople,
                Countries = e.CountryTrips.Select(t => new GetTripsCountryDTO()
                {
                    Name = t.Country.Name,
                }).ToList(),
                Clients = e.ClientTrips.Select(t => new GetTripsClientDTO()
                {
                    FirstName = t.Client.FirstName,
                    Lastname = t.Client.LastName
                }).ToList()
            }).ToList()
        });
    }

    [HttpPost("{idTrip}/clients")]
    public async Task<IActionResult> AssignClientToTrip(AssignClientToTripDTO clientDTO)
    {
        var existingClient = await _dbService.GetClientByPesel(clientDTO.Pesel);
        if (existingClient != null)
        {
            return BadRequest("Client with this pesel already exists");
        }
        
        if (await _dbService.ClientIsAssignedToTrip(clientDTO.Pesel, clientDTO.IdTrip))
        {
            return BadRequest("Client is already assigned to this trip");
        }
        var trip = await _dbService.GetTripById(clientDTO.IdTrip);
        if (trip == null || trip.DateFrom <= DateTime.Now)
        {
            return BadRequest("Trip not found or already taken place");
        }
        
        var client = new Client()
        {
            FirstName = clientDTO.FirstName,
            LastName = clientDTO.LastName,
            Email = clientDTO.Email,
            Telephone = clientDTO.Telephone,
            Pesel = clientDTO.Pesel
        };
        
        await _dbService.AddClient(client);
        
        var clientTrip = new Client_Trip()
        {
            IdClient = client.IdClient,
            IdTrip = trip.IdTrip,
            RegisteredAt = (int)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds,
            PaymentDate = clientDTO.PaymentDate
        };
        
        await  _dbService.AddClientTrip(clientTrip);

        return Created("api/clients", new
        {
            IdClient = client.IdClient,
            FirstName = client.FirstName,
            LastName = client.LastName,
            Email = client.Email,
            Telephone = client.Telephone,
            Pesel = client.Pesel,
            ClientTrips = new List<Client_Trip>
            {
                new Client_Trip
                {
                    IdClient = client.IdClient,
                    IdTrip = clientDTO.IdTrip,
                    RegisteredAt = (int)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds,
                    PaymentDate = clientDTO.PaymentDate
                }
            }
        });
    }
}