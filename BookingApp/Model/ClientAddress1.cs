using System;
using System.Collections.Generic;

namespace BookingApp.Model
{
    public partial class ClientAddress1
    {
        public int Id { get; set; }
        public int? StreetNo { get; set; }
        public int? ZipCode { get; set; }
        public string Area { get; set; }
        public string State { get; set; }
        public string AddressType { get; set; }
        public int BookingId { get; set; }
    }
}
