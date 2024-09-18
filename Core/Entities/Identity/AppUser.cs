using Microsoft.AspNetCore.Identity;

namespace Core.Entities.Identity;

public	 class AppUser:IdentityUser
{
    public string Name { get; set; } = null!;
    public string Surname { get; set; } = null!;
}
