using MediatR;

namespace BuildingContractor.Application.ListOfWorks.Quieres.GetSearchListOfWorksList
{
    public class GetListOfWorksSearchQuery : IRequest<SearchListOfWorksVm>
    {
        public string searchText { get; set; }
    }
}
