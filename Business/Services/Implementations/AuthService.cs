using Business.DTOs.AuthDtos;
using Business.Exceptions.AuthExceptions;
using Business.HelperServices.Interfaces;
using Business.Services.Interfaces;
using Core.Entities.Identity;
using Microsoft.AspNetCore.Identity;

namespace Business.Services.Implementations;

public class AuthService : IAuthService
{
	private readonly UserManager<AppUser> _userManager;
	private readonly SignInManager<AppUser> _signInManager;
	private readonly ITokenService _tokenService;

	public AuthService(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, ITokenService tokenService)
	{
		_userManager = userManager;
		_signInManager = signInManager;
		_tokenService = tokenService;
	}

	public async Task<TokenResponseDto> LoginAsync(LoginDto loginDto)
	{
		var user = await _userManager.FindByNameAsync(loginDto.UserName);
		if (user == null)
			throw new LoginFailedException("Username or password incorrect");
		SignInResult signInResult = await _signInManager.CheckPasswordSignInAsync(user, loginDto.Password, true);
		if(!signInResult.Succeeded)
			throw new LoginFailedException("Username or password incorrect");

		TokenResponseDto tokenResponseDto = _tokenService.GenerateToken(user);

		return tokenResponseDto;
	}
}
