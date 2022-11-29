using AutoMapper;
using BuildingContractor.Application.Common.Mappings;
using BuildingContractor.Application.Licenses.Commands.CreateLicense;

namespace BuildingContractor.WebAPI.Models
{
    public class CreateLicenseDto : IMapWith<CreateLicenseCommand>
    {
        public DateTime createdDate { get; set; }
        public DateTime validaty { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateLicenseDto, CreateLicenseCommand>()
                .ForMember(recordCommand => recordCommand.createDate,
                    opt => opt.MapFrom(recordDto => recordDto.createdDate))
                .ForMember(recordCommand => recordCommand.validaty,
                    opt => opt.MapFrom(recordDto => recordDto.validaty));
        }
    }
}
