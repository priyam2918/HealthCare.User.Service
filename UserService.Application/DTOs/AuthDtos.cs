namespace UserService.Application.DTOs;

public record RegisterUserDto(string UserName, string Email, string Password, Guid OrgId);

public record LoginUserDto(string Email, string Password);

public record AuthResponseDto(Guid UserId, string UserName, string Email, Guid OrgId, string Token, DateTime ExpiresAtUtc);
