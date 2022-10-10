namespace HRISAPI.Services
{
    public class TokenService : ITokenService
    {
        private readonly TokenValidationParameters _tokenValidationParameters;
        private readonly string _secretToken;

        public TokenService(TokenValidationParameters tokenValidationParameters, string secretToken)
        {
            _tokenValidationParameters = tokenValidationParameters;
            _secretToken = secretToken;
        }
        public string GenerateToken(User user)
        {
            var claims = new List<Claim> {               
                new Claim(ClaimTypes.Name, user.Email)               
            };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_secretToken));

            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var token = new JwtSecurityToken(
                    claims: claims,
                    expires: DateTime.Now.AddDays(1),
                    signingCredentials: credentials                    
                );
            var jwt = new JwtSecurityTokenHandler().WriteToken(token);

            return jwt;
        }

        public bool IsValid(string token)
        {
            try
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                tokenHandler.ValidateToken(token, _tokenValidationParameters, out SecurityToken securityToken);
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }
    }
}
