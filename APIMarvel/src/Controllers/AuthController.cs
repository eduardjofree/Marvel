

using ResetPasswordDTO = APIMarvel.src.Application.DTOs.ResetPasswordRequest;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using APIMarvel.src.Application.Interfaces;
using APIMarvel.src.Domain.Entities;
using APIMarvel.src.Application.DTOs;

namespace APIMarvel.src.Controllers
{
    // APIMarvel.API/Controllers/AuthController.cs
    [ApiController]
    [Route("api/auth")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("login")]
        public async Task<ActionResult<RequestUser>> Login([FromBody] RequestUser request)
        {
            var token = await _authService.LoginAsync(request.Email, request.Password);
            return Ok(new { Result = token });
        }

        [HttpPost("forgot-password")]
        public async Task<IActionResult> ForgotPassword([FromBody] ForgotPasswordRequest request)
        {
            var resetToken = await _authService.RequestPasswordResetAsync(request.Email);
            return Ok(new { ResetToken = resetToken });
        }

        [HttpPost("reset-password")]
        public async Task<IActionResult> ResetPassword([FromBody] ResetPasswordDTO request)
        {
            var success = await _authService.ResetPasswordAsync(request.Email, request.Token, request.NewPassword);
            if (!success) return BadRequest("El token es inválido o ha expirado.");
            return Ok("Contraseña restablecida correctamente.");
        }
    }
}
