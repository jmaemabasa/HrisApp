using HrisApp.Shared.Models.Employee;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HrisApp.Shared.Models.User
{
    public class UserMasterT
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }
        public EmployeeT? Employee { get; set; }
        public int EmployeeId { get; set; }
        public string Emp_VerifyId { get; set; } = string.Empty;
        [Required]
        public string Username { get; set; } = string.Empty;
        [Required]
        public string Password { get; set; } = string.Empty;
        public string UserStatus { get; set; } = string.Empty;
        public string Role { get; set; } = string.Empty;
        public byte[]? PasswordHash { get; set; }
        public byte[]? PasswordSalt { get; set; }
        public string LoginStatus { get; set; } = string.Empty;
        public string ReferralCode { get; set; } = string.Empty;

    }
}
