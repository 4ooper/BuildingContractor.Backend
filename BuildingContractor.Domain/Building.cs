namespace BuildingContractor.Domain
{
    public class Building
    {
        public int id { get; set; }
        public int customerID { get; set; }
        public Customer customer { get; set; }
        public int contractorID { get; set; }
        public Contractor contractor { get; set; }
        public DateTime conlusionDate { get; set; }
        public DateTime deliveryDate { get; set; }
        public DateTime comissioningDate { get; set; }
    }
}
