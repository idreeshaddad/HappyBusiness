using AutoMapper;
using MB.MCPP.HappyBusiness.Dtos.Classifications;
using MB.MCPP.HappyBusiness.Entities;

namespace MB.MCPP.HappyBusiness.Api.AutoMapperProfiles
{
    public class ClassificationAutoMapperProfile : Profile
    {
        public ClassificationAutoMapperProfile()
        {
            CreateMap<Classification, ClassificationDto>().ReverseMap();
        }
    }
}
