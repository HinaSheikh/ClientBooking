using BookingApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookingApp.Repository
{
    public interface IEmailSender
    {
        Task<int> SendEmailAsync (int BookingId);
    }
}
