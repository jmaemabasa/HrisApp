using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HrisApp.Shared.Models.User
{
    public class ChangePassDTO
    {
        [Required]
        public string Password { get; set; } = string.Empty;
        [Required]
        [Compare("Password", ErrorMessage = "The passwords do not match.")]
        public string ConfirmPassword { get; set; } = string.Empty;
    }
}
