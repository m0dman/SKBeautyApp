using AutoMapper;
using WebAPI.Application.Requests.Bookings.Commands;
using WebAPI.Application.Requests.Bookings.Queries;
using WebAPI.Domain.Entities;

namespace RandoxHealth.Application.Common.Profiles
{
    public class BookingProfile : Profile
    {
        public BookingProfile()
        {
            //Default mapping when property names are same
            CreateMap<Booking, BookingDTO>();
            CreateMap<Booking, BookingDTO>();

            CreateMap<CreateBookingDTO, Booking>();
            // CreateMap<UpdateBookingDTO, Booking>();
        }
    }
}