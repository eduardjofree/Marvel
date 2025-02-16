using APIMarvel.src.Application.Interfaces;
using APIMarvel.src.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace APIMarvel.src.Controllers
{
    public class UserController: ControllerBase
    {
        private IAuthService _userRepository;

        private readonly IUserRepository _userService;
        public UserController(IUserRepository userService)
        {
            _userService = userService;
        }

        [HttpPost("register")]
        public async Task<ActionResult<User>> CreateUser([FromBody] User ObjtUser)
        {
            try
            {
                var result = await _userService.CreateUserAsync(ObjtUser);
                if (result != null)
                {
                    return Ok(1);
                }
                else
                {
                    return Ok(0);
                }
            }
            catch (Exception e)
            {
                return Ok(e.Message);
            }

        }
    }
}
