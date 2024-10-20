using Microsoft.AspNetCore.Mvc;
using BusinessLogic;
using ProductManagement.API.Models;

namespace ProductManagement.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly UserValidationServices _userValidationServices;

        public UserController()
        {
            _userValidationServices = new UserValidationServices();
        }

        [HttpPost("login")]
        public IActionResult Login(User user)
        {
            if (_userValidationServices.CheckIfUserExists(user.Username, user.Password))
            {
                return Ok("Login successful");
            }
            return Unauthorized("Invalid username or password");
        }
    }
}        
