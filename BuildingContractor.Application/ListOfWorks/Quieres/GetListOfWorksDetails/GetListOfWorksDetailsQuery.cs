using MediatR;

namespace BuildingContractor.Application.ListOfWorks.Quieres.GetListOfWorksDetails
{
    public class GetListOfWorksDetailsQuery : IRequest<ListOfWorksDetailsVm>
    {
        public int id { get; set; }
    }
}
