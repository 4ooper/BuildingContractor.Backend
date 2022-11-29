using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildingContractor.Application.Services.Quieres.GetServicesList
{
    public class ServicesListVm
    {
        public IList<ServiceLookupDto> services { get; set; }
        public int totalElements { get; set; }
        public int pagesCount { get; set; }
    }
}
