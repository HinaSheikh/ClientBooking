using BookingApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookingApp.Repository
{
    public interface IClientRepository
    {
        Task<List<Client>> GetClientsAsync();
        Task<Client> GetClientAsync(int? Id);
        Task<int> AddClientAsync(Client Client);
        Task<int> DeleteClientAsync(int? Id);
        Task<bool> UpdateClientAsync(Client Client);
    }
}
