using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildingContractor.Application.ListOfWorks.Quieres.GetListOfWorksList
{
    public class ListOfWorksVm
    {
        public IList<ListOfWorksLookupDto> listOfWorks { get; set; }
        public int totalElements { get; set; }
        public int pagesCount { get; set; }
    }
}
