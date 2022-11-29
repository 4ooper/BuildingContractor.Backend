using MediatR;

namespace BuildingContractor.Application.Services.Quieres.GetServiceDetails
{
    public class GetServiceDetailsQuery : IRequest<ServiceDetailsVm>
    {
        public int id { get; set; }
    }
}
