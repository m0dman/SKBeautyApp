using System.Collections.Generic;
using MediatR;

namespace WebAPI.Application.Requests.Bookings.Queries
{
    public class GetBookingsQuery : IRequest<IEnumerable<BookingDTO>>
    {
    }
}
