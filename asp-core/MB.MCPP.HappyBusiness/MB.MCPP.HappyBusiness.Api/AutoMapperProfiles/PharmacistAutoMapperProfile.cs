using AutoMapper;
using MB.MCPP.HappyBusiness.Dtos.Pharmacists;
using MB.MCPP.HappyBusiness.Entities;

namespace MB.MCPP.HappyBusiness.Api.AutoMapperProfiles
{
    public class PharmacistAutoMapperProfile : Profile
    {
        public PharmacistAutoMapperProfile()
        {
            CreateMap<PharmacistDto, Pharmacist>();
            CreateMap<Pharmacist, PharmacistListDto>();
            CreateMap<Pharmacist, PharmacistDetailsDto>();
        }
    }
}
