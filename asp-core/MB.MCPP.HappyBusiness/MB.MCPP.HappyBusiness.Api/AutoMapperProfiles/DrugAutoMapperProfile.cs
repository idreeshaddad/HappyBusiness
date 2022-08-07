using AutoMapper;
using MB.MCPP.HappyBusiness.Dtos.Drugs;
using MB.MCPP.HappyBusiness.Entities;

namespace MB.MCPP.HappyBusiness.Api.AutoMapperProfiles
{
    public class DrugAutoMapperProfile : Profile
    {
        public DrugAutoMapperProfile()
        {
            CreateMap<Drug, DrugListDto>();
            //CreateMap<Drug, DrugDetailsDto>();
            CreateMap<DrugDto, Drug>();
        }
    }
}
