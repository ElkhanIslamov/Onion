using Business.DTOs.UserDtos;
using Business.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class UsersController : ControllerBase
	{
		private readonly IUserService _userService;

		public UsersController(IUserService userService)
		{
			_userService = userService;
		}
		[HttpPost]
		public async Task<IActionResult>Creat(UserCreateDto userCreateDto)
		{
			await _userService.CreateUserAsync(userCreateDto);
			return StatusCode((int)HttpStatusCode.Created, $"User : {userCreateDto.Name} succesfully created ");
		}
	}
}
