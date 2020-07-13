using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookingApp.Model
{
    public class Logs
    {
        public int Id { get; set; }
        public string LogMesssage { get; set; }
        public DateTime Date { get; set; }
        public int BookingId { get; set; }
        //public virtual ClientBooking  ClientBooking { get; set; }
        
    
    }
}
