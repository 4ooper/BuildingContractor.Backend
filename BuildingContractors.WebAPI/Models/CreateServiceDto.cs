using AutoMapper;
using BuildingContractor.Application.Common.Mappings;
using BuildingContractor.Application.Services.Commands.CreateService;
using BuildingContractor.Domain;

namespace BuildingContractor.WebAPI.Models
{
    public class CreateServiceDto : IMapWith<CreateServiceCommand>
    {
        public int price { get; set; }
        public int discount { get; set; }
        public ListOfWorkDto listOfWork { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateServiceDto, CreateServiceCommand>()
                .ForMember(customerCommand => customerCommand.price,
                    opt => opt.MapFrom(customerDto => customerDto.price))
                .ForMember(customerCommand => customerCommand.discount,
                    opt => opt.MapFrom(customerDto => customerDto.discount))
                .ForMember(customerCommand => customerCommand.listOfWorkID,
                    opt => opt.MapFrom(customerDto => customerDto.listOfWork.id));
        }
    }
}
