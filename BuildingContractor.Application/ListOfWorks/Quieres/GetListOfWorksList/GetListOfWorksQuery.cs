using MediatR;

namespace BuildingContractor.Application.ListOfWorks.Quieres.GetListOfWorksList
{
    public class GetListOfWorksQuery : IRequest<ListOfWorksVm>
    {
        public int page { get; set; }
    }
}
