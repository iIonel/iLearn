using ILearn.Domain.DTOs.Auth;
using ILearn.Domain.Enums;
using ILearn.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace ILearn.API.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        private readonly IJwtService _jwtService;
        private readonly IConfiguration _configuration;

        public AuthController(IAuthService authService, IJwtService jwtService, IConfiguration configuration)
        {
            _authService = authService;
            _jwtService = jwtService;
            _configuration = configuration;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginUserDto dto)
        {
            try
            {   
                var result = await _authService.Login(dto);
                if (result.Item1 == null)
                    return Unauthorized("Invalid credentials!");
                var jwt = await _jwtService.CreateToken((int)result.Item1,(Roles)result.Item2, _configuration);
                Console.WriteLine($"Result: {(int)result.Item1}, {((Roles)result.Item2).ToString()}");
                return Ok(jwt);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("register/mentor")]
        public async Task<IActionResult> RegisterMentor([FromBody] RegisterMentorDto dto)
        {
            try
            {
                await _authService.RegisterMentor(dto);
                return Ok("Mentor registered successfully!");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("register/student")]
        public async Task<IActionResult> RegisterStudent([FromBody] RegisterStudentDto dto)
        {
            try
            {
                await _authService.RegisterStudent(dto);
                return Ok("Student registered successfully!");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
