using Business.DTOs.UserDtos;

namespace Business.Services.Interfaces;

public	interface IUserService
{
	Task CreateUserAsync(UserCreateDto userCreateDto);
}
