using System;
using WebAPI.Domain.Entities;

namespace WebAPI.Application.Requests.Bookings.Commands
{
    public class CreateBookingDTO
    {
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string TelephoneNumber { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime Date { get; set; }
        public int BranchID { get; set; }
        public int TreatmentID { get; set; }
    }
}