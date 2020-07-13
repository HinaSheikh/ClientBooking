using BookingApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookingApp.DTO
{
    public class ClientBookingDto
    {
        public int? Id { get; set; }
        public DateTime? Date { get; set; }
        public int? Time { get; set; }
        public int ClientId { get; set; }
        public ICollection<ClientBookingAddressDto> ClientBookingAddress { get; set; }
    }
}
