using WebApplication1.Models;

namespace WebApplication1.Services;

public interface IDbService
{
    Task<ICollection<Trip>> GetTripsSorted(int page, int pageSize);
    Task<int> GetTotalTripsCount();
    Task<Client?> GetClientById(int idClient);
    Task DeleteClient(Client client);
    Task<bool> ClientHasTrips(int idClient);
    Task<Client?> GetClientByPesel(string clientDtoPesel);
    Task<bool> ClientIsAssignedToTrip(string clientDtoPesel, int clientDtoIdTrip);
    Task<Trip?> GetTripById(int clientDtoIdTrip);
    Task AddClient(Client client);
    Task AddClientTrip(Client_Trip clientTrip);
}