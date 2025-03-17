using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using Employee_Management_System_API.Services;
using Employee_Management_System_API.DTOs;
using Employee_Management_System_API.Helpers;

namespace Employee_Management_System_API.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IJwtHelper _tokenService;

        public AuthController(IUserService userService, IJwtHelper tokenService)
        {
            _userService = userService ?? throw new ArgumentNullException(nameof(userService), "User service cannot be null.");
            _tokenService = tokenService ?? throw new ArgumentNullException(nameof(tokenService), "Token service cannot be null.");
        }

        // Access only Admin
        [Authorize(Roles = "Admin")]
        [HttpPost("register")]
        public async Task<IActionResult> RegisterHR(UserRegisterDTO model)
        {
            try
            {
                if (model == null) return BadRequest("Invalid request data.");

                var adminIdClaim = User.FindFirst(ClaimTypes.NameIdentifier);
                if (adminIdClaim == null)
                {
                    return Unauthorized("Invalid token, Admin ID not found.");
                }

                var adminId = Guid.Parse(adminIdClaim.Value);
                var result = await _userService.RegisterHR(model.Username, model.Password, "HR", adminId);

                if (!result)
                {
                    return BadRequest("Only Admins can add HR users.");
                }

                return Ok("HR registered successfully.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while registering HR: {ex.Message}");
            }
        }

        // Access can be both Admin and HR (if HR is registered)
        [HttpPost("login")]
        public async Task<IActionResult> Login(UserLoginDTO loginDto)
        {
            try
            {
                if (loginDto == null) return BadRequest("Invalid login data.");

                var user = await _userService.Authenticate(loginDto.Username, loginDto.Password);
                if (user == null)
                {
                    return Unauthorized("Invalid username or password.");
                }

                var token = _tokenService.GenerateToken(user);

                return Ok(new
                {
                    Token = token,
                    Username = user.Username,
                    Role = user.Role
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while logging in: {ex.Message}");
            }
        }
    }
}
