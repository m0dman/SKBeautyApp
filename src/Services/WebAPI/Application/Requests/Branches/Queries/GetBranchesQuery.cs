using System.Collections.Generic;
using MediatR;

namespace WebAPI.Application.Requests.Branches.Queries
{
    public class GetBranchesQuery : IRequest<IEnumerable<BranchDTO>>
    {
    }
}
