using AutoMapper;
using WebAPI.Domain.Entities;
using WebAPI.Application.Requests.Branches.Queries;

namespace RandoxHealth.Application.Common.Profiles
{
    public class BranchProfile : Profile
    {
        public BranchProfile()
        {
            //Default mapping when property names are same
            CreateMap<Branch, BranchDTO>();
        }
    }
}