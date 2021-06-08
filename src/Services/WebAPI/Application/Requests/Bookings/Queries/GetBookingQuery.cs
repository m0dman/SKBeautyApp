using MediatR;

namespace WebAPI.Application.Requests.Bookings.Queries
{
    public class GetBookingQuery : IRequest<BookingDTO>
    {
        public int Id { get; set; }

        public GetBookingQuery(int id)
        {
            Id = id;
        }
    }
}
