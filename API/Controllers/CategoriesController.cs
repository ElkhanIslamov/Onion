using Business.DTOs.BusinesDtos;
using Business.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CategoriesController : ControllerBase
	{
		private readonly ICategoryService _categoryService;

		public CategoriesController(ICategoryService categoryService)
		{
			_categoryService = categoryService;
		}

		[HttpGet]
		public async Task<IActionResult> GetAll(string search)
		{
			return Ok(await _categoryService.GetAllCategoriesAsync(search));

		}
		[HttpGet("{id}")]
		public async Task<IActionResult>GetById(int id)
		{
			return Ok(await _categoryService.GetByIdAsync(id));
		}
		[HttpPost]
		public async Task<IActionResult>Create(CategoryPostDto categoryPostDto)
		{
			await _categoryService.AddAsync(categoryPostDto);
			return StatusCode((int)HttpStatusCode.Created);
		}
	}
}
