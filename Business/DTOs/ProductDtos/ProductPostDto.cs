using Microsoft.AspNetCore.Http;

namespace Business.DTOs.ProductDtos;

public	 class ProductPostDto
{
	public string Name { get; set; }
	public string Description { get; set; }
	public double Price { get; set; }
	public IFormFile Image { get; set; }
	public int Rating { get; set; }
    public int CategoryId { get; set; }
}
