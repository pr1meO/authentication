using Authentication.Contracts;
using Authentication.Interfaces.Auth;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Authentication.Controllers
{
    [AllowAnonymous]
    [ApiController]
    [Route("api/auth")]
    public class AuthController : ControllerBase
    {
        private readonly IIdentityService _identityService;

        public AuthController(IIdentityService identityService)
        {
            _identityService = identityService;
        }

        [HttpPost]
        public IActionResult Login([FromBody] LoginUserRequest request)
        {
            if (string.IsNullOrWhiteSpace(request.Login) || 
                string.IsNullOrWhiteSpace(request.Password))
            {
                return BadRequest(new
                {
                    Message = "Login and password are required."
                });
            }

            var token = _identityService.Login(request.Login, request.Password);

            if (token == null)
            {
                return Unauthorized(new
                {
                    Message = "Invalid login or password."
                });
            }

            return Ok(token);
        }
    }
}