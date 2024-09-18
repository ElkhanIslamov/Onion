using AutoMapper;
using Business.DTOs.BusinesDtos;
using Business.Exceptions.CategoryExceptions;
using Business.Services.Interfaces;
using Core.Entities;
using DataAccess.Repository.Interface;

namespace Business.Services.Implementations;

public class CategoryService : ICategoryService
{
	private readonly IRepository<Category> _repository;
	private readonly IMapper _mapper;

	public CategoryService(IRepository<Category> repository, IMapper mapper)
	{
		_repository = repository;
		_mapper = mapper;
	}

	public async Task<List<CategoryGetDto>> GetAllCategoriesAsync(string? search)
	{
		var categories = await _repository.GetFilteredAsync(c=>search !=null ? c.Name.ToLower()
		.Contains(search.ToLower()):true && !c.IsDeleted);
		var categoriesGetDto = _mapper.Map<List<CategoryGetDto>>(categories);
		return categoriesGetDto;

	}

	public async Task<CategoryGetDto> GetByIdAsync(int id)
	{
		var category = await _repository.GetSingleAsync(c=>c.Id == id && !c.IsDeleted);
		if (category == null)
			throw new CategoryNotFoundByIdException($"Category not found by id: {id}");
		var categoryGetDto = _mapper.Map<CategoryGetDto>(category);
		return categoryGetDto;

	}
	public async Task СreateCategoryAsync(CategoryPostDto category)
	{
		bool isExsist = await _repository.IsExistAsync(c => c.Name == category.Name && !c.IsDeleted);
		if (isExsist)
			throw new CategoryAlreadyExistException($"Category name: {category.Name} already exist!");

		var newCategory = _mapper.Map<Category>(category);

		await _repository.AddAsync(newCategory);
		await _repository.SaveAsync();
	}

}
