using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BookingApp.Model
{
   
    public partial class Client
    {
       // internal IEnumerable<object> ClientBookingAddress;

        public Client()
        {
            ClientBooking = new HashSet<ClientBooking>();
            ClientContact = new HashSet<ClientContact>();
        }

        public int Id { get; set; }
        [Required(ErrorMessage = "Please Provide Name")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Please Provide Email")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Please Provide Date of birth")]
        public DateTime DateOfBirth { get; set; }
          [Required(ErrorMessage = "Please Provide Home Address")]
        public string HomeAddress { get; set; }

        public virtual ICollection<ClientBooking> ClientBooking { get; set; }
        [Required(ErrorMessage = "Please Provide Contact No ")]
        public virtual ICollection<ClientContact> ClientContact { get; set; }
    }
}
