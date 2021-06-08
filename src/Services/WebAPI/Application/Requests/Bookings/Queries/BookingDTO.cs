using System;
using WebAPI.Domain.Entities;

namespace WebAPI.Application.Requests.Bookings.Queries
{
    public class BookingDTO
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public string Address { get; set; }
        public string TelephoneNumber { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public DateTime Date { get; set; }
        public Branch Branch { get; set; }
        public Treatment Treatment { get; set; }
    }
}