using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
        [HttpPost]
        public IActionResult User(UserLogin user)
        {
            var result = _loginService.User(user); // result = null, token as string

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
        public async Task<List<User>> GetAllUsers()
        {
            return await _loginService.GetAllUsers();
        }
    }
}
