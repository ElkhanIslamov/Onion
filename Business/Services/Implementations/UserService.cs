using AutoMapper;
using Business.DTOs.UserDtos;
using Business.Exceptions.UserExceptions;
using Business.Services.Interfaces;
using Core.Entities.Identity;
using Microsoft.AspNetCore.Identity;

namespace Business.Services.Implementations;

public class UserService : IUserService
{
	private readonly UserManager<AppUser> _usermanager;
	private readonly IMapper _mapper;

	public UserService(UserManager<AppUser> usermanager, IMapper mapper)
	{
		_usermanager = usermanager;
		_mapper = mapper;
	}

	public async Task CreateUserAsync(UserCreateDto userCreateDto)
	{
		AppUser user = _mapper.Map<AppUser>(userCreateDto);
		
		IdentityResult identityResult = await _usermanager.CreateAsync(user,userCreateDto.Password);
		if (!identityResult.Succeeded) 
		throw new CreateFailedException(identityResult.Errors);
	}
}
