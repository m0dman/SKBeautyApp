using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using WebAPI.Application.Requests.Branches.Queries;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using WebAPI.Application.Common.Interfaces;
using WebAPI.Application.Requests.Bookings.Queries;
using WebAPI.Application.Requests.Bookings.Commands;

namespace WebAPI.Application.CommandHandlers.Branches
{
    public class BookingQueryHandler :
        IRequestHandler<GetBookingQuery, BookingDTO>,
        IRequestHandler<GetBookingsQuery, IEnumerable<BookingDTO>>
    {
        private readonly IDbContextFactory _dBContextFactory;
        private readonly IMapper _Mapper;

        public BookingQueryHandler(IDbContextFactory dBContextFactory, IMapper mapper)
        {
            _dBContextFactory = dBContextFactory;
            _Mapper = mapper;
        }

        /// <summary>
        /// Handles when a call is made to get all of the Bookings in the database.
        /// </summary>
        /// <param name="request">The GetBookingsQuery that is being passed through.</param>
        /// <param name="cancellationToken">The cancellation token that cancels the request.</param>
        /// <returns>A list of all the Bookings.</returns>
        public async Task<IEnumerable<BookingDTO>> Handle(GetBookingsQuery request, CancellationToken cancellationToken)
        {
            var context = _dBContextFactory.GetGenericContext();
            return await context.Bookings
                .ProjectTo<BookingDTO>(_Mapper.ConfigurationProvider)
                .OrderBy(t => t.FirstName)
                .ToListAsync(cancellationToken);
        }

        /// <summary>
        /// Handles when a call is made to get an Booking in the database.
        /// </summary>
        /// <param name="request">The GetBookingQuery that is being passed through.</param>
        /// <param name="cancellationToken">The cancellation token that cancels the request.</param>
        /// <returns>A single Booking.</returns>
        public async Task<BookingDTO> Handle(GetBookingQuery request, CancellationToken cancellationToken)
        {
            var context = _dBContextFactory.GetGenericContext();
            return await context.Bookings
                .ProjectTo<BookingDTO>(_Mapper.ConfigurationProvider)
                .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);
        }
    }
}
