using Business.DTOs.ProductDtos;
using Business.Exceptions.ProductExceptions;
using Business.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ProductsController : ControllerBase
	{
        private readonly IProductService _productService;

		public ProductsController(IProductService productService)
		{
			_productService = productService;
		}
		[HttpGet]
		public async Task<IActionResult> GetAll(string? search) 
		{
			return Ok(await _productService.GetAllProductsAsync(search));
		}
        [HttpGet("{id}")]
        public async Task<IActionResult>GetById(int id)
		{
			
				return Ok(await _productService.GetByIdAsync(id));

			
		}
		[HttpPost]
		public async Task<IActionResult>Create([FromForm] ProductPostDto productPostDto)
		{
			await _productService.AddAsync(productPostDto);
			return StatusCode((int)HttpStatusCode.Created, "Product sucsessfully created");
		}
		[HttpPut("{id}")]
		public async Task<IActionResult>Update(int id, ProductPutDto productPutDto)
		{
				await _productService.UpdateAsync(id, productPutDto);
				return NoContent();		
		}
    }
}
