using System.Net.NetworkInformation;
using System.Security.Cryptography;


namespace HRISAPI.Repositories.UTILITY
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        private readonly ITokenService _tokenService;

        public UserRepository(HRISDbContext context, ITokenService tokenService) : base(context)
        {
            _tokenService = tokenService;
        }

        public async Task<string?> Login(UserLoginRequest userLoginRequest)
        {
            var user = await GetUser(userLoginRequest.Email);

            if (user == null)
                return string.Empty;

            var foundUser = await _table
                .Where(x => x.Email == userLoginRequest.Email
                                    && VerifyPasswordHash(userLoginRequest.Password, user.PasswordHash, user.PasswordSalt))
                .FirstOrDefaultAsync();

            return foundUser != null ? _tokenService.GenerateToken(foundUser) : string.Empty;
        }

        public async Task Register(UserRegisterRequest request)
        {
            CreatePasswordHash(request.Password, out byte[] passwordHash, out byte[] passwordSalt);
            var user = new User
            {
                Email = request.Email,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                VerificationToken = CreateRandomToken()
            };
            await _table.AddAsync(user);
        }

        public async Task VerifyAccount(string Token)
        {
            var user = await _table.FirstOrDefaultAsync(u => u.VerificationToken == Token);
            if (user != null)
                user.VerifiedAtTime = DateTime.Now;
        }

        public async Task ForgotPassword(string Email)
        {
            var user = await GetUser(Email);
            if (user != null)
            {
                user.PasswordResetToken = CreateRandomToken();
                user.ResetTokenExpires = DateTime.Now.AddDays(1);
            }
        }

        public async Task<bool> ResetPassword(ResetPasswordRequest request)
        {
            var user = await _table.FirstOrDefaultAsync(u => u.PasswordResetToken == request.Token);

            if (user == null || user.ResetTokenExpires < DateTime.Now)
                return false;

            CreatePasswordHash(request.Password, out byte[] passwordHash, out byte[] passwordSalt);
            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;
            user.PasswordResetToken = null;
            user.ResetTokenExpires = null;

            return true;
        }

        public async Task<User?> GetUser(string Email)
        {
            return await _table.FirstOrDefaultAsync(u => u.Email == Email);
        }

        public void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using var hmac = new HMACSHA512();
            passwordSalt = hmac.Key;
            passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));

        }
        public bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using var hmac = new HMACSHA512(passwordSalt);
            var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            return computedHash.SequenceEqual(passwordHash);
        }
        public string CreateRandomToken()
        {
            return Convert.ToHexString(RandomNumberGenerator.GetBytes(64));
        }

    }
}
