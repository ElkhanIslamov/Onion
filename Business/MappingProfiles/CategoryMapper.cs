using AutoMapper;
using Business.DTOs.BusinesDtos;
using Core.Entities;

namespace Business.MappingProfiles;

public class CategoryMapper:Profile
{
    public CategoryMapper()
    {
        CreateMap<Category, CategoryGetDto>().ReverseMap(); 
        CreateMap<CategoryPostDto,Category>().ForMember(x=>x.CreatedDate,y=>y.MapFrom(x=>DateTime.UtcNow))
            .ForMember(x=>x.UpdatedDate,y=>y.MapFrom(x=>DateTime.UtcNow)).ReverseMap();
    }

}
