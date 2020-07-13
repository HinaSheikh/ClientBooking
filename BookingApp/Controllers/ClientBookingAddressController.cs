using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BookingApp.Model;
using BookingApp.Repository;

namespace BookingApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientBookingAddressController : ControllerBase
    {
        private readonly IClientAddressRepository clientAddressRepository;

        public ClientBookingAddressController(IClientAddressRepository context)
        {
            clientAddressRepository = context;
        }

        // GET: api/ClientBookingAddresses
        [HttpGet]
        public IActionResult GetClientBookingAddress()
        {
            var addressList = clientAddressRepository.GetAllClientBookingsAddresses();
            if (addressList == null)
            {
                return NotFound();
            }

            return Ok(addressList);
        }

        //GET: api/ClientBookingAddresses/5
        [HttpGet("{Id}")]
        public IActionResult GetClientBookingAddress(int Id)
        {
            var clientBookingAddress = clientAddressRepository.GetClientBookingsAddressForBooking(Id);

            if (clientBookingAddress == null)
            {
                return NotFound();
            }

            return Ok(clientBookingAddress);
        }
    }
}
