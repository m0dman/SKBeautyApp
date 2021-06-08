using AutoMapper;
using WebAPI.Domain.Entities;
using WebAPI.Application.Requests.Treatments.Queries;

namespace RandoxHealth.Application.Common.Profiles
{
    public class TreatmentProfile : Profile
    {
        public TreatmentProfile()
        {
            //Default mapping when property names are same
            CreateMap<Treatment, TreatmentDTO>();
        }
    }
}