namespace WebAPI.Application.Requests.Treatments.Queries
{
    public class TreatmentDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Price { get; set; }
        public int BranchID { get; set; }
    }
}