using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using WebAPI.Application.Requests.Bookings.Commands;
using WebAPI.Application.Requests.Bookings.Queries;
using WebAPI.Domain.Entities;
using WebAPI.Application.Common.Interfaces;

namespace WebAPI.Application.CommandHandlers.Bookings
{
    public class BookingCommandHandler :
        IRequestHandler<CreateBookingCommand, int>
        // IRequestHandler<UpdatePanelCommand, bool>
    {
        private readonly IDbContextFactory _dBContextFactory;
        private readonly IMapper _Mapper;

        public BookingCommandHandler(IMapper mapper, IDbContextFactory dBContextFactory)
        {
            _Mapper = mapper;
            _dBContextFactory = dBContextFactory;
        }

        /// <summary>
        /// Handles when a call is made to create an Booking in the database.
        /// </summary>
        /// <param name="request">The CreateBookingCommand that is being passed through.</param>
        /// <param name="cancellationToken">The cancellation token that cancels the request.</param>
        /// <returns>The Int of the new Booking.</returns>
        public async Task<int> Handle(CreateBookingCommand request, CancellationToken cancellationToken)
        {
            var context = _dBContextFactory.GetGenericContext();
            Booking mappedRecord = _Mapper.Map<Booking>(request.Booking);

            Treatment existingTreatment = await context.Treatments.FirstOrDefaultAsync(x => x.Id == request.Booking.TreatmentID);
            mappedRecord.AddTreatment(existingTreatment);
            Branch existingBranch = await context.Branches.FirstOrDefaultAsync(x => x.Id == request.Booking.BranchID);
            mappedRecord.AddBranch(existingBranch);

            context.Bookings.Add(mappedRecord);
            await context.SaveChangesAsync(cancellationToken);

            return mappedRecord.Id;
        }
    }
}
