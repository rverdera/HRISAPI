namespace HRISAPI.Contracts.Service;

public interface ITokenService
{
    string GenerateToken(User user);
    bool IsValid(string token);
}
