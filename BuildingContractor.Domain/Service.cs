namespace BuildingContractor.Domain
{
    public class Service
    {
        public int id { get; set; }
        public int price { get; set; }
        public int discount { get; set; }
        public int listOfWorkID { get; set; }
        public listOfWork listOfWork { get; set; }
    }
}
