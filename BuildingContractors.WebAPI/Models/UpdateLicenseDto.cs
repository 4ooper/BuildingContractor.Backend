using AutoMapper;
using BuildingContractor.Application.Common.Mappings;
using BuildingContractor.Application.Licenses.Commands.UpdateLicense;

namespace BuildingContractor.WebAPI.Models
{
    public class UpdateLicenseDto : IMapWith<UpdateLicenseCommand>
    {
        public int id { get; set; }
        public DateTime createdDate { get; set; }
        public DateTime validaty { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<UpdateLicenseDto, UpdateLicenseCommand>()
                .ForMember(recordCommand => recordCommand.id,
                    opt => opt.MapFrom(recordDto => recordDto.id))
                .ForMember(recordCommand => recordCommand.createDate,
                    opt => opt.MapFrom(recordDto => recordDto.createdDate))
                .ForMember(recordCommand => recordCommand.validaty,
                    opt => opt.MapFrom(recordDto => recordDto.validaty));
        }
    }
}
