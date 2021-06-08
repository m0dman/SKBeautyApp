using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebAPI.Application.Requests.Bookings.Queries;
using WebAPI.Application.Requests.Bookings.Commands;

namespace WebAPI.API.Controllers
{

    [ApiController]
    [AllowAnonymous]
    [Route("[controller]/[action]")]
    public class BookingController : ApiController
    {
        private readonly ILogger<BookingController> _Logger;

        public BookingController(ILogger<BookingController> logger)
        {
            _Logger = logger;
        }

        /// <summary>
        /// Get all Bookings
        /// </summary>
        /// <returns>An IEnumerable of Booking records</returns>
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<BookingDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> Get()
        {
            IEnumerable<BookingDTO> result = await Mediator.Send(new GetBookingsQuery());

            if (result.Any())
                return Ok(result);

            return StatusCode(204, "No Bookings found.");
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(BookingDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> GetBooking(int id)
        {
            BookingDTO result = await Mediator.Send(new GetBookingQuery(id));

            if (result != null)
                return Ok(result);

            return StatusCode(204, "No Booking found for that ID.");
        }

        /// <summary>
        /// Creates an Booking using the info provided.
        /// </summary>
        /// <param name="booking">The Booking information that will be used to create a new Booking.</param>
        /// <returns>The ID of the newly created Booking</returns>
        [HttpPost]
        [ProducesResponseType(typeof(int), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> CreateBooking([FromBody] CreateBookingDTO booking)
        {
            int result = await Mediator.Send(new CreateBookingCommand(booking));

            if (result != 0)
                return Ok(result);

            return StatusCode(204, "Could not create Booking.");
        }
    }
}
