using MediatR;

namespace WebAPI.Application.Requests.Treatments.Queries
{
    public class GetTreatmentQuery : IRequest<TreatmentDTO>
    {
        public int Id { get; set; }

        public GetTreatmentQuery(int id)
        {
            Id = id;
        }
    }
}
