﻿namespace POS.Application.Dtos.Response;
internal class UserResponseDto
{
    public int UserId { get; set; }
    public string Name { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string Email { get; set; } = null!;
}
