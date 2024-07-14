using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net.Sockets;
using TrainStationTracker.core.Data;
using TrainStationTracker.core.DTO;
using TrainStationTracker.core.IService;

namespace TrainStationTracker.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly ILoginService _loginService;

        public LoginController(ILoginService loginService)
        {
            _loginService = loginService;
        }

        [HttpGet]
        public Task<bool> CheckUsername(string username)
        {
            return _loginService.CheckUsername(username);
        }
    
    [HttpPost]
        public IActionResult Login(UserLogin user)
        {
            var result = _loginService.Login(user); // result = null, token as string

            if (result == null)
            {
                return Unauthorized();
            }
            else
            {
                return Ok(result);
            }
        }
        [HttpPost]
        public async Task Register(Register user)
        {
            await _loginService.Register(user);
        }
        [HttpGet]
        [CheckClaims("RoleId", "1")]
        public async Task<List<User>> GetAllUsers()
        {
            return await _loginService.GetAllUsers();
        }
        [HttpPut]
        public async Task<IActionResult> UpdateProfile(UpdatProfile user)
        {
            
            var userIdString = User.FindFirst("Userid")?.Value;

            if (userIdString == null)
            {
                return Unauthorized("User ID not found in JWT token");
            }

            if (!int.TryParse(userIdString, out int userId))
            {
                return BadRequest("Invalid user ID format");
            }

            try
            {
                user.Userid = userId;
                await _loginService.UpdateProfile(user);
                return Ok("Updated profile successfully");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }
        [HttpGet("{id}")]
        public async Task<User> GetUserById(int id)
        {
            return await _loginService.GetUserById(id);
        }
    }
}
