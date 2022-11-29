using MediatR;

namespace BuildingContractor.Application.Customers.Quieres.GetCustomerList
{
    public class GetCustomerListQuery : IRequest<CustomerListVm>
    {
        public int page { get; set; }
    }
}
