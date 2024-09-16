using Business.DTOs.AuthDtos;
using Business.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class AuthController : ControllerBase
	{
		private readonly IAuthService _authService;

		public AuthController(IAuthService authService)
		{
			_authService = authService;
		}
		[HttpPost("[action]")]
		public async Task<IActionResult> Login(LoginDto loginDto)
		{
			var tokenResponse = await _authService.LoginAsync(loginDto);

			return Ok(tokenResponse);
		}

	}
}
