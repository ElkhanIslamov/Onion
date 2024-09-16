namespace Business.DTOs.AuthDtos;
public class TokenResponseDto
{
    public string Token { get; set; } = null!;
    public DateTime ExpiresDate { get; set; }
}
