using BookingApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookingApp.DTO
{
    public class ClientDto
    {
        public ClientDto()
        {
            ClientBooking = new HashSet<ClientBookingDto>();
            ClientContact = new HashSet<ClientContactDto>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string HomeAddress { get; set; }

        public virtual ICollection<ClientBookingDto> ClientBooking { get; set; }
        public virtual ICollection<ClientContactDto> ClientContact { get; set; }
    }
}
