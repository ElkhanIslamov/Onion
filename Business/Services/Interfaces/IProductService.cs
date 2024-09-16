using Business.DTOs.ProductDtos;

namespace Business.Services.Interfaces;

public interface IProductService
{
	Task<List<ProductGetDto>> GetAllProductsAsync(string? search);
	Task<ProductGetDto>GetByIdAsync(int id);
	Task AddAsync(ProductPostDto productPostDto);
	Task UpdateAsync(int id, ProductPutDto productPutDto);
	Task DeleteAsync(int id);

}
