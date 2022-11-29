using AutoMapper;
using BuildingContractor.Application.Common.Mappings;
using BuildingContractor.Domain;
using BuildingContractor.Application.ListOfWorks.Quieres.GetListOfWorksList;

namespace BuildingContractor.Application.Services.Quieres.GetServiceDetails
{
    public class ServiceDetailsVm : IMapWith<Service>
    {
        public int id { get; set; }
        public int price { get; set; }
        public int discount { get; set; }
        public ListOfWorksLookupDto listOfWork { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Service, ServiceDetailsVm>()
                .ForMember(customerDto => customerDto.id, opt => opt.MapFrom(customer => customer.id))
                .ForMember(customerDto => customerDto.price, opt => opt.MapFrom(customer => customer.price))
                .ForMember(customerDto => customerDto.listOfWork, opt => opt.MapFrom(customer => customer.listOfWork))
                .ForMember(customerDto => customerDto.discount, opt => opt.MapFrom(customer => customer.discount));
        }
    }
}
