using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Registration.Model;
using Registration.Service;

namespace Registration.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class UsersController : ControllerBase
    {
        private UserManagerService _userManagerService;

        public UsersController(UserManagerService userManagerService)
        {
            _userManagerService = userManagerService;
        }

        [HttpPost]
        public async Task<User[]> GetUsers() 
        {
            return await _userManagerService.GetAllUsers();
        }

        [HttpPost]
        public async Task<IActionResult> RegistrationUser([FromBody] UserDto userDto)
        {
            await _userManagerService.UserRegistration(userDto);

            return Ok();
        }




    }
}
