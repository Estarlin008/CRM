using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Reflection;

namespace CRMApi.Identity
{
    [Area("Identity")]
    [DisplayName("Authentication Controller")]
    [Route("api/[area]/[controller]")]
    [ApiController]
    public class AuthenticationController(IAuthenticationService authenticationService): ControllerBase
    {
        [HttpPost("login")]
        [DisplayName("Login")]
       public async Task<IActionResult> Login([FromBody] ApplicationUserInputModel model)
        {
           var response = await authenticationService.LoginAsync(model);
           return Ok(response);
        }

        [HttpPost("register")]
        [DisplayName("Register")]
        public async Task<IActionResult> Register([FromBody] ApplicationUserInputModel model)
        {
          var response = await authenticationService.RegisterAsync(model);
          return Ok(response);
        }

        [HttpPost("forgot-password")]
        [DisplayName("Forgot Password")]
        public async Task<IActionResult> ForgotPassword([FromBody] ApplicationUserInputModel model)
        {
            var response = await authenticationService.ForgotPasswordAsync(model);
            return Ok(response);
        }

        [HttpPost("reset-password")]
        [DisplayName("Reset Password")]
        public async Task<IActionResult> ResetPassword([FromBody] ApplicationUserInputModel model)
        {
            var response = await authenticationService.ResetPasswordAsync(model);
            return Ok(response);
        }
    }

  
}