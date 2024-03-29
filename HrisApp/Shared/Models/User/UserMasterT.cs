﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HrisApp.Shared.Models.Employee;
using HrisApp.Shared.Models.StaticData;

namespace HrisApp.Shared.Models.User
{
    public class UserMasterT
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }
        public EmployeeT? Employee { get; set; }
        public int EmployeeId { get; set; }
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
