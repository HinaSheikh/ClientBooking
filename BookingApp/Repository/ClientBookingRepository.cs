using BookingApp.DTO;
using BookingApp.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace BookingApp.Repository
{
    public class ClientBookingRepository : IClientBookingRepository
    {

        BookingContext db;
        public ClientBookingRepository(BookingContext _db)
        {
            db = _db;
        }
        public async Task<int> AddBookingAsync(ClientBooking Booking)
        {

            int count = db.ClientBooking.Where(C => C.ClientId == Booking.ClientId && C.Date == Booking.Date).Count();
            if (count < 4)
            {
                await db.ClientBooking.AddAsync(Booking);
                await db.SaveChangesAsync();
                return Booking.Id;
            }
            return -1;
        }

        public async Task<int> DeleteBookingAsync(int Id)
        {
            int result = 0;
            //Find the Client for specific Client id
            var booking = await db.ClientBooking.FirstOrDefaultAsync(x => x.Id == Id);

            if (booking != null)
            {
                //Delete that Booking
                db.ClientBooking.Remove(booking);
                //Commit the transaction
                result = await db.SaveChangesAsync();
            }
            return result;
        }

        public IEnumerable<ClientBooking> GetAllBookings()
        {
            return db.ClientBooking.Include(c => c.ClientBookingAddress).ToList();
        }

        public ClientBooking GetBooking(int Id)
        {
            return db.ClientBooking.Include(c => c.ClientBookingAddress).Where(c => c.Id == Id).FirstOrDefault();
        }

        public IEnumerable<ClientBooking> GetBookingsForClient(int clientId, DateTime date)
        {
            var booking = db.ClientBooking.Where(c => c.ClientId == clientId);
            if (date != default(DateTime))
            {
                booking = booking.Where(c => c.Date == date);
            }
            return booking.Include(c => c.ClientBookingAddress).ToList();
        }

        public async Task<bool> UpdateBookingAsync(ClientBooking Booking)
        {
            db.ClientBooking.Update(Booking);
            await db.SaveChangesAsync();
            return true;
        }
    }
}
