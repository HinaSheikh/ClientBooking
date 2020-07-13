using BookingApp.DTO;
using BookingApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookingApp.Repository
{
    public  interface IClientBookingRepository
    {
        IEnumerable<ClientBooking> GetAllBookings();
        IEnumerable<ClientBooking> GetBookingsForClient(int clientId,DateTime date);
        ClientBooking GetBooking(int Id);
        Task<int> AddBookingAsync(ClientBooking Boking);
        Task<bool> UpdateBookingAsync(ClientBooking Booking);
        Task<int> DeleteBookingAsync(int Id);
    }
}
