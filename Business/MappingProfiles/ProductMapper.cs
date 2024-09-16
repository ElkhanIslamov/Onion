using AutoMapper;
using Business.DTOs.ProductDtos;
using Core.Entities;

namespace Business.MappingProfiles;

public class ProductMapper:Profile
{
    public ProductMapper()
    {
        CreateMap<Product,ProductGetDto>().ReverseMap();
        CreateMap<ProductPostDto,Product>().ForMember(x=> x.CreatedDate, y=>y.MapFrom(x=>DateTime.UtcNow))
            .ForMember(x=>x.UpdatedDate,y=>y.MapFrom(x=>DateTime.UtcNow))
            .ForMember(x=>x.IsInStock,y=>y.MapFrom(x => true)).ReverseMap();
        CreateMap<ProductPutDto,Product>().ForMember(x=>x.UpdatedDate,y=>y.MapFrom(x=> DateTime.UtcNow))
            .ReverseMap();

    }
}
