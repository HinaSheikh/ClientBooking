using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookingApp.Model
{
    public partial class ClientBookingAddress
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int? Id { get; set; }

        public int? ZipCode { get; set; }
        [Required(ErrorMessage = "Please Provide Street No")]
        public int StreetNo { get; set; }
        [Required(ErrorMessage = "Please Provide House No")]
        public int HouseNo { get; set; }
        [Required(ErrorMessage = "Please Provide Ares")]
        public string Area { get; set; }
        [Required(ErrorMessage = "Please Provide Date of birth")]
        public string State { get; set; }
        [Required(ErrorMessage = "Please Provide Address Type")]
        public string AddressType { get; set; }
        [System.ComponentModel.DataAnnotations.Schema.Column("BookingId")]
        public int ClientBookingId { get; set; }
        public virtual ClientBooking Booking { get; set; }
    }
}
