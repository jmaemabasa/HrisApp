using System.ComponentModel.DataAnnotations;

namespace HrisApp.Shared.Models.User
{
    public class ChangePassDTO
    {
        [Required(ErrorMessage = "This field is required.")]
        public string CurrentPassword { get; set; } = string.Empty;
        [Required(ErrorMessage = "This field is required.")]
        public string Password { get; set; } = string.Empty;
        [Required(ErrorMessage = "This field is required.")]
        [Compare("Password", ErrorMessage = "The passwords do not match.")]
        public string ConfirmPassword { get; set; } = string.Empty;
    }
}
