using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookingApp.DTO
{
    public class ClientBookingAddressDto
    {
        public int? Id { get; set; }
        public int? ZipCode { get; set; }
        public int StreetNo { get; set; }
        public int HouseNo { get; set; }
        public string Area { get; set; }
        public string State { get; set; }
        public string AddressType { get; set; }

    }
}
