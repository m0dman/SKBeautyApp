using System.Collections.Generic;
using MediatR;

namespace WebAPI.Application.Requests.Treatments.Queries
{
    public class GetTreatmentByBranchIDQuery : IRequest<IEnumerable<TreatmentDTO>>
    {
        public int BranchID { get; set; }

        public GetTreatmentByBranchIDQuery(int branchID)
        {
            BranchID = branchID;
        }
    }
}
