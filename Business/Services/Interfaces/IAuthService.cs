using Business.DTOs.AuthDtos;

namespace Business.Services.Interfaces;

public	interface IAuthService
{
	Task<TokenResponseDto> LoginAsync(LoginDto loginDto);
}
