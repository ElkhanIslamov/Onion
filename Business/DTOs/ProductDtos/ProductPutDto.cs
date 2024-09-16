namespace Business.DTOs.ProductDtos;

public	 class ProductPutDto
{
	public string Name { get; set; }
	public string Description { get; set; }
	public double Price { get; set; }
	public bool IsInStock { get; set; }
	public string Image { get; set; }
	public int Rating { get; set; }

}
