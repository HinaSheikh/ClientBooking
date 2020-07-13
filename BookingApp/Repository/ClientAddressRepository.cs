using BookingApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookingApp.Repository
{
    public class ClientAddressRepository : IClientAddressRepository
    {
        BookingContext db;
        public ClientAddressRepository(BookingContext _db)
        {
            db = _db;
        }
        public int AddClientBookingAddress(ClientBookingAddress address)
        {
            throw new NotImplementedException();
        }
        public int DeleteClientBookingAddress(int Id)
        {
            throw new NotImplementedException();
        }
        public IEnumerable<ClientBookingAddress> GetAllClientBookingsAddresses()
        {
            if (db != null)
            {
                return db.Set<ClientBookingAddress>().ToList();
            }

            return null;
        }

        public IEnumerable<ClientBookingAddress> GetClientBookingsAddressForBooking(int bookingId)
        {
            if (db != null)
            {
                return db.ClientBookingAddress.Where(c => c.ClientBookingId == bookingId).ToList();
            }
            return null;
        }

        public int UpdateClientBookingAddress(ClientBookingAddress address)
        {
            throw new NotImplementedException();
        }
    }
}
