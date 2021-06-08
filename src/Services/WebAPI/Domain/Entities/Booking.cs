using System;
using System.Collections.Generic;
using System.Linq;

namespace WebAPI.Domain.Entities
{
    public class Booking
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

        #region Constructors

        /// <summary>
        /// private, parameterless constructor used by EF core
        /// </summary>
        private Booking() {}

        public Booking(string firstName, string surname, string address, string telephoneNumber, string phoneNumber, string email, Treatment treatment, Branch branch)
        {
            if (treatment == null)
                Treatment = treatment;
            if (branch == null)
                Branch = branch;
            FirstName = firstName;            
            Surname = surname; 
            Address = address;
            TelephoneNumber = telephoneNumber; 
            PhoneNumber = phoneNumber; 
            Email = email; 
        }

        /// <summary>
        /// Adds an treatment to the Analyser.
        /// </summary>
        /// <param name="treatment">The treatment model to be added.</param>
        public void AddTreatment(Treatment treatment)
        {
            if (treatment == null)
                throw new ArgumentNullException(nameof(treatment));

            Treatment = treatment;
        }

        /// <summary>
        /// Adds an Analyser to the Instrument model.
        /// </summary>
        /// <param name="analyser">The Analyser model that will be added.</param>
        public void AddBranch(Branch branch)
        {
            if (branch == null)
                throw new ArgumentNullException(nameof(branch));

            Branch = branch;
        }

        #endregion
    }
}