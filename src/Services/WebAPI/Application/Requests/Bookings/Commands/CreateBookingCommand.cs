using System;
using MediatR;

namespace WebAPI.Application.Requests.Bookings.Commands
{
    public class CreateBookingCommand : IRequest<int>
    {
        public CreateBookingDTO Booking { get; set; }

        public CreateBookingCommand(CreateBookingDTO booking)
        {
            Booking = booking;
        }
    }
}
