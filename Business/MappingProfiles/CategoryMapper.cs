using AutoMapper;
using Business.DTOs.BusinesDtos;
using Core.Entities;

namespace Business.MappingProfiles;

public class CategoryMapper:Profile
{
    public CategoryMapper()
    {
        CreateMap<Category, CategoryGetDto>().ReverseMap(); 
        CreateMap<CategoryPostDto,Category>().ReverseMap();
    }

}
