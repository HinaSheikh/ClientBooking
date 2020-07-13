using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.Configuration;
using BookingApp.DTO;
using BookingApp.Model;
using BookingApp.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;


namespace BookingApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientBookingController : ControllerBase
    {
        private readonly IClientBookingRepository clientRepository;
        private readonly IEmailSender emailSender;
        private readonly IMapper mapper;
        private readonly Microsoft.Extensions.Configuration.IConfiguration configuration;

        public ClientBookingController(IClientBookingRepository context, IMapper _mapper, Microsoft.Extensions.Configuration.IConfiguration _configuration,IEmailSender _emailSender)
        {
            clientRepository = context;
            mapper = _mapper;
            configuration = _configuration;
            emailSender = _emailSender;
        }

        // GET: api/ClientBooking
        [HttpGet]
        public IActionResult GetClientBookings()
        {
            var bookings = clientRepository.GetAllBookings();
            return Ok(mapper.Map<IEnumerable<ClientBookingDto>>(bookings));
        }

        [HttpGet("{id}")]
        public IActionResult GetBookingForClient(int id, DateTime date = default(DateTime))
        {
            var booking = clientRepository.GetBookingsForClient(id, date);
            if (booking.Count() == 0)
                return NotFound();
            return Ok(mapper.Map<IEnumerable<ClientBookingDto>>(booking));
        }

        [HttpPost]
        public async Task<ActionResult<int>> PostClientBooking(ClientBookingDto booking)
        {
            if (ModelState.IsValid)
            {
                ClientBooking clientBooking = mapper.Map<ClientBooking>(booking);
                var bookingId = await clientRepository.AddBookingAsync(clientBooking);
                if (bookingId > 0)
                {
                    int logId = await emailSender.SendEmailAsync(bookingId);
                    if(logId >0)
                    return Ok(bookingId);
                }
                else
                {
                    if (bookingId == -1)
                        return NoContent();
                    return NotFound();
                }
            }
            return BadRequest();
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteBooking(int id)
        {
            int result = 0;
            if (id == 0)
            {
                return BadRequest();
            }
            result = await clientRepository.DeleteBookingAsync(id);
            if (result == 0)
            {
                return NotFound();
            }
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> PutClientBooking(ClientBookingDto booking)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            ClientBooking updatedBooking = mapper.Map<ClientBooking>(booking);
            bool result = await clientRepository.UpdateBookingAsync(updatedBooking);
            if (result)
                return NoContent();
            return NotFound();
        }
    }
}
