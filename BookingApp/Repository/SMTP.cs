using BookingApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookingApp.Repository
{
    public class SMTP : IEmailSender
    {
        BookingContext db;
        public SMTP(BookingContext _db)
        {
            db = _db;
        }
        public async Task<int> SendEmailAsync(int bookingId)
        {
            Logs log = new Logs
            {
                LogMesssage = "Email delivered using SMTP",
                Date = DateTime.Today,
                BookingId = bookingId
            };
            await db.Logs.AddAsync(log);
            await db.SaveChangesAsync();
            return log.Id;
        }
    }
}
