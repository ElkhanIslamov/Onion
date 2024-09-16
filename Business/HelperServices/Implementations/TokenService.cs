using Business.DTOs.AuthDtos;
using Business.HelperServices.Interfaces;
using Core.Entities.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Text.Unicode;

namespace Business.HelperServices.Implementations;

public class TokenService : ITokenService
{
	private readonly IConfiguration _configuration;

	public TokenService(IConfiguration configuration)
	{
		_configuration = configuration;
	}

	public TokenResponseDto GenerateToken(AppUser appUser)
	{
		List<Claim> claims = new List<Claim>()
		{
			new Claim(ClaimTypes.Name, appUser.UserName),
			new Claim(ClaimTypes.Email, appUser.Email),
			new Claim(ClaimTypes.NameIdentifier, appUser.Id)
		};
		SymmetricSecurityKey symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8
			.GetBytes(_configuration["Jwt:SecurityKey"]));
		SigningCredentials signingCredentials = new SigningCredentials(symmetricSecurityKey,
			SecurityAlgorithms.HmacSha256);

		JwtSecurityToken jwtSecurityToken = new JwtSecurityToken(
			issuer: _configuration["Jwt:Issuer"], 
			audience: _configuration["Jwt:Audience"], 
			claims:claims, 
			expires:DateTime.UtcNow.AddHours(2),
			signingCredentials: signingCredentials
		);
		 
		JwtSecurityTokenHandler jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
		   string token =  jwtSecurityTokenHandler.WriteToken(jwtSecurityToken);
		
		
		return new TokenResponseDto
		{
			Token = token,
			ExpiresDate = jwtSecurityToken.ValidTo
		};
 	}
}
