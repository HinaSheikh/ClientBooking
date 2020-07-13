using BookingApp.Model;
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace BookingApp.Repository
{
    public class ClientRepository : IClientRepository
    {
        BookingContext db;
        public ClientRepository(BookingContext _db)
        {
            db = _db;
        }
        public async Task<int> AddClientAsync(Client Client)
        {
            await db.Client.AddAsync(Client);
            await db.SaveChangesAsync();
            return Client.Id;
        }

        public async Task<int> DeleteClientAsync(int? Id)
        {
            int result = 0;
            //Find the Client for specific Client id
            var Client = await db.Client.FirstOrDefaultAsync(x => x.Id == Id);
            if (Client != null)
            {
                //Delete that Client
                db.Client.Remove(Client);
                //Commit the transaction
                result = await db.SaveChangesAsync();
            }
            return result;
        }

        public async Task<Client> GetClientAsync(int? id)
        {
            Client client = await db.Client.Include(c => c.ClientContact).Include(b =>
            b.ClientBooking).ThenInclude(e => e.ClientBookingAddress).Where(d => d.Id == id).FirstOrDefaultAsync();
            if (client == null)
            {
                return null;
            }
            return client;
        }

        public async Task<List<Client>> GetClientsAsync()
        {
            return await db.Client.Include(c => c.ClientContact).Include(c => c.ClientBooking).ThenInclude(e => e.ClientBookingAddress).ToListAsync();
        }
        public async Task<bool> UpdateClientAsync(Client client)
        {
            db.Client.Update(client);
            await db.SaveChangesAsync();
            return true;
        }
    }
}
