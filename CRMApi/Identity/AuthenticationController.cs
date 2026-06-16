using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Reflection;
using System.Net;
using CRM.Service.IService;
using CRM.Model.InputModels;

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
       public async Task<IActionResult> Login([FromBody] ApplicationUserLoginInputModel model)
        {
           var response = await authenticationService.LoginAsync(model);
           return response.IsSuccess ? Ok(response) : StatusCode(500);
        }

        [HttpPost("register")]
        [DisplayName("Register")]
        public async Task<IActionResult> Register([FromBody] ApplicationUserRegisterImputModel model)
        {
          var response = await authenticationService.RegisterAsync(model);
          return response? Ok(response) : StatusCode(500);
        }

        [HttpPost("forgot-password")]
        [DisplayName("Forgot Password")]
        public async Task<IActionResult> ForgotPassword([FromBody] ApplicationUserRegisterImputModel model)
        {
            var response = await authenticationService.ForgotPasswordAsync(model);
            return response ? Ok(response) : StatusCode(500);
        }

        [HttpPost("reset-password")]
        [DisplayName("Reset Password")]
        public async Task<IActionResult> ResetPassword([FromBody] ApplicationUserRegisterImputModel model)
        {
            var response = await authenticationService.ResetPasswordAsync(model);
            return response ? Ok(response) : StatusCode(500);
        }
    }

  
}