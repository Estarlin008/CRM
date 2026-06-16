using CRM.Model.InputModels;
using CRM.Model.ApplicationModels;
namespace CRM.Service.IService
{
    public interface IAuthenticationService
    {
        Task<ResponseModel<bool>> LoginAsync(ApplicationUserLoginInputModel model);
        Task<bool> RegisterAsync(ApplicationUserRegisterImputModel model);
        Task<bool> ForgotPasswordAsync(ApplicationUserRegisterImputModel model);
        Task<bool> ResetPasswordAsync(ApplicationUserRegisterImputModel model);
        Task<bool> ChangePasswordAsync(ApplicationUserRegisterImputModel model);
        Task<bool> RefreshTokenAsync(ApplicationUserRegisterImputModel model);
    }
}