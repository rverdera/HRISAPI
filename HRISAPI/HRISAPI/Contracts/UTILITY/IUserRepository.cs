namespace HRISAPI.Contracts.UTILITY
{
    public interface IUserRepository : IBaseRepository<User>
    {
        Task<string?> Login(UserLoginRequest userLoginRequest);
        Task Register(UserRegisterRequest request);
        Task VerifyAccount(string Token);
        Task ForgotPassword(string Email);
        Task<bool> ResetPassword(ResetPasswordRequest request);
        Task<User?> GetUser(string Email);
        void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt);
        bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt);
        string CreateRandomToken();
        
    }
}
