using AutoMapper;
using Business.DTOs.ProductDtos;
using Core.Entities;

namespace Business.MappingProfiles;

public class ProductMapper:Profile
{
    public ProductMapper()
    {
        CreateMap<Product,ProductGetDto>().ReverseMap();
        CreateMap<ProductPostDto,Product>().ForMember(x=>x.IsInStock,y=>y.MapFrom(x => true)).ReverseMap();
        CreateMap<ProductPutDto,Product>().ReverseMap();

    }
}
