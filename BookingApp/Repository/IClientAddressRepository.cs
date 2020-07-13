using BookingApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookingApp.Repository
{
    public interface IClientAddressRepository
    {
        IEnumerable<ClientBookingAddress> GetAllClientBookingsAddresses();
        IEnumerable<ClientBookingAddress> GetClientBookingsAddressForBooking(int bookingId);
        int AddClientBookingAddress(ClientBookingAddress address);
        int UpdateClientBookingAddress(ClientBookingAddress address);
        int DeleteClientBookingAddress(int Id);

    }
}
