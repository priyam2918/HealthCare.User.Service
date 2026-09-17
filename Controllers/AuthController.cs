using BuildingBlocks.Common.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using UserService.Application.Commands.LoginUser;
using UserService.Application.Commands.RegisterUser;
using UserService.Application.DTOs;

namespace UserService.API.Controllers;

// Matches the Sample APIs doc: POST /api/users/login, POST /api/users/register
[ApiController]
[Route("api/users")]
public class AuthController : ControllerBase
{
    private readonly IMediator _mediator;

    public AuthController(IMediator mediator) => _mediator = mediator;

    [HttpPost("register")]
    [ProducesResponseType(typeof(ApiResponse<AuthResponseDto>), StatusCodes.Status201Created)]
    public async Task<IActionResult> Register([FromBody] RegisterUserDto dto)
    {
        var result = await _mediator.Send(new RegisterUserCommand(dto.UserName, dto.Email, dto.Password, dto.OrgId));
        return StatusCode(StatusCodes.Status201Created, ApiResponse<AuthResponseDto>.Ok(result, "User registered successfully."));
    }

    [HttpPost("login")]
    [ProducesResponseType(typeof(ApiResponse<AuthResponseDto>), StatusCodes.Status200OK)]
    public async Task<IActionResult> Login([FromBody] LoginUserDto dto)
    {
        var result = await _mediator.Send(new LoginUserCommand(dto.Email, dto.Password));
        return Ok(ApiResponse<AuthResponseDto>.Ok(result, "Login successful."));
    }
}
