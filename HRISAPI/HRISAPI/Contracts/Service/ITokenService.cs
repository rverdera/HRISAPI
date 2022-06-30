namespace HRISAPI.Contracts.Service;

public interface ITokenService
{
    string GenerateToken();
    bool IsValid(string token);
}
