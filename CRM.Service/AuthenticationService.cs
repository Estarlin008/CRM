using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;
using CRM.Model.IdentityModels;
using CRM.Model.InputModels;
using CRM.Service.IService;
using Microsoft.AspNetCore.Identity;
using CRM.Model.ApplicationModels;
namespace CRM.Service;

public class AuthenticationService(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager): IAuthenticationService
{

    public Task<bool> ChangePasswordAsync(ApplicationUserRegisterImputModel model)
    {
        throw new NotImplementedException();
    }

    public Task<bool> ForgotPasswordAsync(ApplicationUserRegisterImputModel model)
    {
        throw new NotImplementedException();
    }

    public async Task<ResponseModel<bool>> LoginAsync(ApplicationUserLoginInputModel model)
    {

        var result = await signInManager.PasswordSignInAsync(model.Email, model.Password, false, false);
        if (result.Succeeded)
        {
            return new ResponseModel<bool>
            {
                IsSuccess = true,
                Message = "Login successful.",
                Data = true
            };
        }

        string errorMessage = result.IsLockedOut ? "User account is locked out." :
                              result.IsNotAllowed ? "Login is not allowed." :
                              result.RequiresTwoFactor ? "Two-factor authentication is required." :
                              "Invalid login attempt.";

        return new ResponseModel<bool>
        {
            IsSuccess = false,
            Message = errorMessage,
            Data = false
        };
    }

    public Task<bool> RefreshTokenAsync(ApplicationUserRegisterImputModel model)
    {
        throw new NotImplementedException();
    }

    public async Task<bool> RegisterAsync(ApplicationUserRegisterImputModel model){
        ArgumentNullException.ThrowIfNull(model.Email);
        ArgumentNullException.ThrowIfNull(model.Password);
        var user = new ApplicationUser
        {
            Email = model.Email,
            UserName = model.Email,
            FirstName = model.FirstName,
            LastName = model.LastName,
            DateOfBirth = model.DateOfBirth,
            Gender = model.Gender,
            registrationDate = DateTime.UtcNow
        };

        var result = await userManager.CreateAsync(user, model.Password);
        return result.Succeeded? true: throw new Exception("Unable create user, Error: " + result.Errors);
    }

    public Task<bool> ResetPasswordAsync(ApplicationUserRegisterImputModel model){
        throw new NotImplementedException();
    }
}
