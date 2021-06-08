using System;
using System.Collections.Generic;
using System.Linq;

namespace WebAPI.Domain.Entities
{
    public class Branch
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public HashSet<Treatment> _treatments;
        public IEnumerable<Treatment> Treatments => _treatments?.ToList();

        #region Constructors

        /// <summary>
        /// private, parameterless constructor used by EF core
        /// </summary>
        private Branch() {}

        public Branch(string name, string address, ICollection<Treatment> treatments = null)
        {
            if (treatments == null)
                treatments = new List<Treatment>();
            Name = name;            
            Address = address;
        }

        #endregion
    }
}