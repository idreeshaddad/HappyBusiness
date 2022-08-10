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
            CreateMap<DealDto, Deal>();
            CreateMap<Deal, DealDetailsDto>();

            //CreateMap<Deal, DealDetailsDto>()
            //    .ForMember(
            //        dest => dest.DrugStreetNames, 
            //        opts => opts.MapFrom(src => src.Drugs.Select(d => d.StreetName)));

        }
    }
}
