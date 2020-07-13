using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BookingApp.Model
{
    [Bind("Phone")]
    public partial class ClientContact
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Please Provide  Phone No ")]
        public int Phone { get; set; }
        [BindRequired]
        public int ClientId { get; set; }
        public virtual Client Client { get; set; }
    }
}
