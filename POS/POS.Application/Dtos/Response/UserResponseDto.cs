namespace POS.Application.Dtos.Response;

public class UserResponseDto
{
    public int UserId { get; set; }
    public string Name { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string Email { get; set; } = null!;
    public byte Status { get; set; }
}
