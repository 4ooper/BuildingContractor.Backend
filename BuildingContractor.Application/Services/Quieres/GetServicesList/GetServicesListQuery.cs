using MediatR;


namespace BuildingContractor.Application.Services.Quieres.GetServicesList
{
    public class GetServicesListQuery : IRequest<ServicesListVm>
    {
        public int page { get; set; }
    }
}
