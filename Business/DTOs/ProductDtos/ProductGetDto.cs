using Business.DTOs.BusinesDtos;
using Core.Entities;

namespace Business.DTOs.ProductDtos;

public class ProductGetDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public double Price { get; set; }
    public bool IsInStock { get; set; }
    public string Image { get; set; }
    public int Rating { get; set; }
    public CategoryGetDto Category{ get; set; }
}
