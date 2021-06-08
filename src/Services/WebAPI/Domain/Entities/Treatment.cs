namespace WebAPI.Domain.Entities
{
    public class Treatment
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public string Price { get; set; }
        public Branch Branch {get; private set; }

        #region Constructors

        /// <summary>
        /// private, parameterless constructor used by EF core
        /// </summary>
        private Treatment() {}

        public Treatment(string name, string price)
        {
            Name = name;            
            Price = price;
        }

        #endregion
    }
}