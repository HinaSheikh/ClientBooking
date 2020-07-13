using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace BookingApp.Model
{
    public partial class ClientBooking
    {
        public ClientBooking()
        {
            ClientBookingAddress = new HashSet<ClientBookingAddress>();
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required(ErrorMessage = "Please Provide Date")]
        public DateTime? Date { get; set; }
        [Required(ErrorMessage = "Please Provide Time ")]
        public int? Time { get; set; }
        [Required(ErrorMessage = "Please Provide Client Id  ")]
        public int ClientId { get; set; }

        public virtual Client Client { get; set; }
        [Required(ErrorMessage = "Please Provide Booking Addresses")]
        public virtual ICollection<ClientBookingAddress> ClientBookingAddress { get; set; }
    }
}
