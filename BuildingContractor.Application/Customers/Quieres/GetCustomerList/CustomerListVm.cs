using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildingContractor.Application.Customers.Quieres.GetCustomerList
{
    public class CustomerListVm
    {
        public IList<CustomerLookupDto> customers { get; set; }
    }
}
