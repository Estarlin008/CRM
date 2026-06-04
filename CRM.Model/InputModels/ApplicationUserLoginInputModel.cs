using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;
namespace CRM.Model.InputModels
{
    public class ApplicationUserLoginInputModel
    {
        [Required]
        [EmailAddress]
        public required string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        public required string Password { get; set; }
    }
}