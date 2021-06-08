using MediatR;

namespace WebAPI.Application.Requests.Branches.Queries
{
    public class GetBranchQuery : IRequest<BranchDTO>
    {
        public int Id { get; set; }

        public GetBranchQuery(int id)
        {
            Id = id;
        }
    }
}
