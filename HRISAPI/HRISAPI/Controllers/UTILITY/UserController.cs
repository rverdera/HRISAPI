namespace HRISAPI.Controllers.UTILITY
{

    public class UserController : BaseController<User>
    {
        private readonly IUserRepository _repository;
        public UserController(IUserRepository repository) : base(repository)
        {
            _repository = repository;
        }

        [HttpPost("Register"), AllowAnonymous]
        public async Task<IActionResult> Register(UserRegisterRequest request)
        {
            if (await _repository.GetUser(request.Email) != null)
            {
                return BadRequest("User already exists.");
            }
            await _repository.Register(request);
            await _repository.SaveChangesAsync();
            return Ok("User succesfully Created");
        }

        [HttpPost("Login"), AllowAnonymous]
        public async Task<ActionResult<string>> Login(UserLoginRequest request)
        {
            var user = await _repository.GetUser(request.Email);
            if (user == null)
            {
                return Unauthorized();
            }
            if (!_repository.VerifyPasswordHash(request.Password, user.PasswordHash, user.PasswordSalt))
            {
                return Unauthorized();
            }
            if (user.VerifiedAtTime == null)
            {
                return BadRequest("Not verified!");
            }
            return Ok(await _repository.Login(request));

        }

        [HttpPost("VerifyAccount"), AllowAnonymous]
        public async Task<IActionResult> VerifyAccount(string token)
        {
            await _repository.VerifyAccount(token);
            await _repository.SaveChangesAsync();
            return Ok("User account verified.");
        }

        [HttpPost("Forgot-Password"), AllowAnonymous]
        public async Task<IActionResult> ForgotPassword(string email)
        {
            await _repository.ForgotPassword(email);
            await _repository.SaveChangesAsync();
            return Ok("You may now reset your password");
        }

        [HttpPost("Reset-Password"), AllowAnonymous]
        public async Task<IActionResult> ResetPassword(ResetPasswordRequest request)
        {
            if (!await _repository.ResetPassword(request))
                return BadRequest("Invalid Token");

            await _repository.SaveChangesAsync();
            return Ok("Password Succesfully reset.");
        }

    }
}
