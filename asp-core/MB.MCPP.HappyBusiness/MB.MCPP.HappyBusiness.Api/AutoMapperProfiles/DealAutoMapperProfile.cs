using AutoMapper;
using MB.MCPP.HappyBusiness.Dtos.Deals;
using MB.MCPP.HappyBusiness.Entities;

namespace MB.MCPP.HappyBusiness.Api.AutoMapperProfiles
{
    public class DealAutoMapperProfile : Profile
    {
        public DealAutoMapperProfile()
        {
            CreateMap<Deal, DealListDto>();
            CreateMap<Deal, DealDetailsDto>();
            CreateMap<DealDto, Deal>();
        }
    }
}
