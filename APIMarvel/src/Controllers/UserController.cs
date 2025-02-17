using APIMarvel.src.Application.DTOs;
using APIMarvel.src.Application.Interfaces;
using APIMarvel.src.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace APIMarvel.src.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class UserController: ControllerBase
    {
        private IAuthService _userRepository;

        private readonly IUserRepository _userService;
        public UserController(IUserRepository userService)
        {
            _userService = userService;
        }

        [HttpPost("register")]
        public async Task<ActionResult<RequestRegistUser>> CreateUser([FromBody] User ObjtUser)
        {
            var result = await _userService.CreateUserAsync(ObjtUser);
            if (!result)
            {
                //return Conflict("El usuario ya existe con este correo o identificación.");
                return Ok(new { result = 0, message = "El usuario ya existe con este correo o identificación." });
            }
            return Ok(new { result = 1, message = "Usuario registrado exitosamente." });

        }

        [HttpGet("profile")]
        [Authorize]
        public async Task<IActionResult> GetUserProfile()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            // Espera el resultado de la tarea asincrónica para obtener el usuario
            var user = await _userService.GetById(int.Parse(userId));

            if (user == null)
            {
                return NotFound();
            }

            // Devuelve los datos del usuario
            return Ok(new
            {
                Id = user.Id,
                Nombre = user.Nombre,
                Identificacion = user.Identificacion,
                Email = user.Email
            });
        }
    }
}
