using MediatR;
using UserService.Application.DTOs;

namespace UserService.Application.Commands.RegisterUser;

public record RegisterUserCommand(string UserName, string Email, string Password, Guid OrgId)
    : IRequest<AuthResponseDto>;
