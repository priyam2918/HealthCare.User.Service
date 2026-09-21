using BuildingBlocks.Common.Entities;

namespace UserService.Domain.Entities;

/// <summary>Matches the Users Table from the design doc.</summary>
public class User : BaseOrgEntity
{
    public string UserName { get; set; } = default!;
    public string Email { get; set; } = default!;

    // Passwords are never stored in plain text or with a single hash alone -
    // PasswordSalt is unique per user and mixed in before hashing (PBKDF2),
    // exactly as the Security section of the design doc specifies.
    public string PasswordHash { get; set; } = default!;
    public string PasswordSalt { get; set; } = default!;

    public Guid RoleId { get; set; }
    public bool IsActive { get; set; } = true;
}
