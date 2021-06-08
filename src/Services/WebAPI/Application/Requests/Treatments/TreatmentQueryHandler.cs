using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using WebAPI.Application.Requests.Treatments.Queries;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using WebAPI.Application.Common.Interfaces;

namespace WebAPI.Application.CommandHandlers.Branches
{
    public class TreatmentQueryHandler :
        IRequestHandler<GetTreatmentQuery, TreatmentDTO>,
        IRequestHandler<GetTreatmentsQuery, IEnumerable<TreatmentDTO>>,
        IRequestHandler<GetTreatmentByBranchIDQuery, IEnumerable<TreatmentDTO>>
    {
        private readonly IDbContextFactory _dBContextFactory;
        private readonly IMapper _Mapper;

        public TreatmentQueryHandler(IDbContextFactory dBContextFactory, IMapper mapper)
        {
            _dBContextFactory = dBContextFactory;
            _Mapper = mapper;
        }

        /// <summary>
        /// Handles when a call is made to get all of the Branches in the database.
        /// </summary>
        /// <param name="request">The GetBranchesQuery that is being passed through.</param>
        /// <param name="cancellationToken">The cancellation token that cancels the request.</param>
        /// <returns>A list of all the Branches.</returns>
        public async Task<IEnumerable<TreatmentDTO>> Handle(GetTreatmentsQuery request, CancellationToken cancellationToken)
        {
            var context = _dBContextFactory.GetGenericContext();
            return await context.Treatments
                .ProjectTo<TreatmentDTO>(_Mapper.ConfigurationProvider)
                .OrderBy(t => t.Name)
                .ToListAsync(cancellationToken);
        }

        /// <summary>
        /// Handles when a call is made to get an Branch in the database.
        /// </summary>
        /// <param name="request">The GetBranchQuery that is being passed through.</param>
        /// <param name="cancellationToken">The cancellation token that cancels the request.</param>
        /// <returns>A single Branch.</returns>
        public async Task<TreatmentDTO> Handle(GetTreatmentQuery request, CancellationToken cancellationToken)
        {
            var context = _dBContextFactory.GetGenericContext();
            return await context.Treatments
                .ProjectTo<TreatmentDTO>(_Mapper.ConfigurationProvider)
                .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);
        }

        /// <summary>
        /// Handles when a call is made to get all of the Branches in the database.
        /// </summary>
        /// <param name="request">The GetBranchesQuery that is being passed through.</param>
        /// <param name="cancellationToken">The cancellation token that cancels the request.</param>
        /// <returns>A list of all the Branches.</returns>
        public async Task<IEnumerable<TreatmentDTO>> Handle(GetTreatmentByBranchIDQuery request, CancellationToken cancellationToken)
        {
            var context = _dBContextFactory.GetGenericContext();
            return await context.Treatments
                .ProjectTo<TreatmentDTO>(_Mapper.ConfigurationProvider)
                .Where(t => t.BranchID == request.BranchID)
                .OrderBy(t => t.Name)
                .ToListAsync(cancellationToken);
        }
    }
}
