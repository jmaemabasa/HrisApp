using System.ComponentModel.DataAnnotations;

namespace HrisApp.Shared.Models.User
{
    public class UpdateUsernameDTO
    {
        public int EmployeeId { get; set; }

        [Required(ErrorMessage = "This field is required.")]
        public string Username { get; set; } = string.Empty;
    }
}
