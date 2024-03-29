﻿using HrisApp.Shared.Models.Employee;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HrisApp.Shared.Models.User
{
    public class UserLoginDto
    {
        public int Id { get; set; }
        public EmployeeT? Employee { get; set; }
        public int EmployeeId { get; set; }
        public string Username { get; set; } = string.Empty;
        //[Required, StringLength(100, MinimumLength = 6)]
        public string Password { get; set; } = string.Empty;
        //[Required]
        //[Compare("Password", ErrorMessage = "The passwords do not match.")]
        public string ConfirmPassword { get; set; } = string.Empty;
        public string UserStatus { get; set; } = string.Empty;
        public byte[]? PasswordHash { get; set; }
        public byte[]? PasswordSalt { get; set; }
        public string LoginStatus { get; set; } = string.Empty;
        public string ReferralCode { get; set; } = string.Empty;
        public string Role { get; set; } = string.Empty;
    }
}
