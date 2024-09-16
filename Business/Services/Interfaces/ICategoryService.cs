using Business.DTOs.BusinesDtos;

namespace Business.Services.Interfaces;

public interface ICategoryService
{
	Task<List<CategoryGetDto>> GetAllCategoriesAsync(string? search);
	Task<CategoryGetDto>GetByIdAsync(int id);	
	Task AddAsync(CategoryPostDto categoryPostDto);
}
