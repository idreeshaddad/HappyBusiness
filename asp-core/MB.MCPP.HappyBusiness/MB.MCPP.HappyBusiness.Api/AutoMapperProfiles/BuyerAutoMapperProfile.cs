using AutoMapper;
using MB.MCPP.HappyBusiness.Dtos.Buyers;
using MB.MCPP.HappyBusiness.Entities;

namespace MB.MCPP.HappyBusiness.Api.AutoMapperProfiles
{
    public class BuyerAutoMapperProfile : Profile
    {
        public BuyerAutoMapperProfile()
        {
            CreateMap<Buyer, BuyerListDto>();
            CreateMap<Buyer, BuyerDetailsDto>();
            CreateMap<BuyerDto, Buyer>();
        }
    }
}
