namespace UserService.Application.Interfaces;

/// <summary>PBKDF2-based hashing per the Security requirement (PasswordSalt + PasswordHash).</summary>
public interface IPasswordHasher
{
    (string Hash, string Salt) HashPassword(string password);
    bool VerifyPassword(string password, string hash, string salt);
}
