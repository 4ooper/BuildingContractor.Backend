namespace BuildingContractor.Application.Customers.Quieres.GetCustomerList
{
    public class CustomerListVm
    {
        public IList<CustomerLookupDto> customers { get; set; }
        public int totalElements { get; set; }
        public int pagesCount { get; set; }
    }
}
