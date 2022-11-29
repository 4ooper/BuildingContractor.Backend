using AutoMapper;
using BuildingContractor.Application.Common.Mappings;
using BuildingContractor.Application.ListOfWorks.Commands.CreateListOfWorks;
using BuildingContractor.Domain;

namespace BuildingContractor.WebAPI.Models
{
    public class CreateListOfWorkDto : IMapWith<CreateListOfWorkCommand>
    {
        public string name { get; set; }
        public LicenseDto license { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateListOfWorkDto, CreateListOfWorkCommand>()
                .ForMember(customerCommand => customerCommand.name,
                    opt => opt.MapFrom(customerDto => customerDto.name))
                .ForMember(customerCommand => customerCommand.licenseID,
                    opt => opt.MapFrom(customerDto => customerDto.license.id));
        }
    }
}
