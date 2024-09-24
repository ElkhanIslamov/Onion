using AutoMapper;
using Business.DTOs.ProductDtos;
using Business.Exceptions.ProductExceptions;
using Business.HelperServices.Interfaces;
using Business.Services.Interfaces;
using Core.Entities;
using DataAccess.Repository.Interface;
using Microsoft.AspNetCore.Http;

namespace Business.Services.Implementations;

public class ProductService : IProductService
{
	private readonly IRepository<Product> _repository;
	private readonly IMapper _mapper;
	private readonly IFileService _fileService;

    public ProductService(IRepository<Product> repository, IMapper mapper, IFileService fileService)
    {
        _repository = repository;
        _mapper = mapper;
        _fileService = fileService;
    }

    public async Task<List<ProductGetDto>> GetAllProductsAsync(string? search)
	{
		var dbProducts = await _repository.GetFilteredAsync(p => search != null ? p.Name.ToLower()
						 .Contains(search.ToLower()) : true && !p.IsDeleted, "Category");
		var products = _mapper.Map<List<ProductGetDto>>(dbProducts);
		return products;
	}
	public async Task<ProductGetDto> GetByIdAsync(int id)
	{
		var product = await _repository.GetSingleAsync(p=>p.Id == id && !p.IsDeleted);
		if (product == null) 
		throw new ProductNotFoundByIdException ($"Product by id: {id} not found");
						
		var productGetDTo = _mapper.Map<ProductGetDto>(product);
		return productGetDTo;
	}
	public async Task AddAsync(ProductPostDto productPostDto)
	{
		Product product = _mapper.Map<Product>(productPostDto);

		string fileName = await  _fileService.UploadAsync(productPostDto.Image, "image/", 3000 );
		product.Image = fileName;

		await _repository.AddAsync(product);
		await _repository.SaveAsync();
	}
	public async Task UpdateAsync(int id, ProductPutDto productPutDto)
	{
		var product = await _repository.GetSingleAsync(p=>p.Id==id && !p.IsDeleted);
		if (product == null)
			throw new ProductNotFoundByIdException($"Product by id: {id} not found");
		_mapper.Map<ProductPutDto>(product);
		_repository.UpdateAsync(product);
		await _repository.SaveAsync();
	}
	public async Task DeleteAsync(int id)
	{
		var product = await _repository.GetSingleAsync(p=> p.Id==id && !p.IsDeleted);
		if (product == null)
			throw new ProductNotFoundByIdException($"Product by id: {id} not found");
		product.IsDeleted = true;
		await _repository.SaveAsync();
	}
}
