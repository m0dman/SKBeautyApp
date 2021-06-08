using System.Collections.Generic;
using MediatR;

namespace WebAPI.Application.Requests.Treatments.Queries
{
    public class GetTreatmentsQuery : IRequest<IEnumerable<TreatmentDTO>>
    {
    }
}
