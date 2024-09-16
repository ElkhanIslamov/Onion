using Business.DTOs.AuthDtos;
using Core.Entities.Identity;

namespace Business.HelperServices.Interfaces;

public interface ITokenService
{
	TokenResponseDto GenerateToken(AppUser appUser);
}
